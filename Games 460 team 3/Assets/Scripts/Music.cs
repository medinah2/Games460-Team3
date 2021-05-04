using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Music : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioSource Player;
    public AudioClip Background;
    public AudioClip Sleep;
    public AudioClip DBD;
    public bool game = true;
    public static bool close = false;
    public bool delay = true;
    public bool off = false;
    public bool off2 = false;
    public static float volume = 9;

    // Start is called before the first frame update
    void Start()
    {
        
        Player.volume = GameObject.FindGameObjectWithTag("GameManagement").GetComponent<sensitivityManager>().audioVolume;
        VolumeSlider.value = Player.volume;
        Player.PlayOneShot(Background,volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(close && game)
        {
            Player.pitch = 1.3f;
            StopAllCoroutines();
            StartCoroutine("Delayed");
            
        }

        if (!close && game && !delay)
        {
            
            Player.pitch = 1f;
            delay = true;
        }

        if(pedestrianController.night)
        {
            Player.pitch = 1f;
        }

        if (!Player.isPlaying && !pedestrianController.night)
        {
            Player.PlayOneShot(Background,volume);
        }

        if(pedestrianController.night && !off)
        {
            Player.Stop();
            Player.volume = .4f;
            off = true;
        }

        if(pedestrianController.night && off && !off2)
        {
            Player.PlayOneShot(Sleep);
            off2 = true;
        }

        if(pedestrianController.night && off & off2 && !Player.isPlaying)
        {
            Player.PlayOneShot(DBD);
        }
    }

    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(5);
        delay = false;
    }
    
     public void AdjustSound(float newVolume) {
    
      Player.volume = Mathf.Clamp(newVolume,0.0f,1.0f);
     

    }
}
