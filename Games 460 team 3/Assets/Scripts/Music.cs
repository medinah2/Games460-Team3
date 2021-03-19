using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Player;
    public AudioClip Background;
    // Start is called before the first frame update
    void Start()
    {
        Player.PlayOneShot(Background);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Player.isPlaying)
        {
            Player.PlayOneShot(Background);
        }
    }
}
