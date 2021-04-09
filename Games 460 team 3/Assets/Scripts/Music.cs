using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Player;
    public AudioClip Background;
    public AudioClip Sleep;
    public AudioClip DBD;
    public bool off = false;
    public bool off2 = false;
    public static float volume = 9;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayOneShot(Background,volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Player.isPlaying && !pedestrianController.night)
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
}
