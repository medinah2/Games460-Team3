using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Player;
    public AudioClip Background;
<<<<<<< HEAD
    public static float volume = 9;
    
    // Start is called before the first frame update
    void Start()
    {
        Player.PlayOneShot(Background,volume);
=======
    // Start is called before the first frame update
    void Start()
    {
        Player.PlayOneShot(Background);
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Player.isPlaying)
        {
<<<<<<< HEAD
            Player.PlayOneShot(Background,volume);
=======
            Player.PlayOneShot(Background);
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
        }
    }
}
