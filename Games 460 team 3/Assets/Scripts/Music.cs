using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Player;
    public AudioClip Background;
    public static float volume = 9;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayOneShot(Background,volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Player.isPlaying)
        {
            Player.PlayOneShot(Background,volume);
        }
    }
}
