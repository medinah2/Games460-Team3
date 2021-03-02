﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public GameObject timer;
    public int minutes = 10;
    public int seconds = 1;
    public bool gracePeriod = true;
    public bool deduct = true;
    // Start is called before the first frame update
    void Start()
    {
        //Added a grace period for players to learn instructions and figure out what to do
        StartCoroutine(Grace());
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gracePeriod == false)
        {
            //Once the grace period is over the timer starts
            if (deduct == true)
            {
                StartCoroutine(Time());
            }
        }
        //Restarts game
        if (minutes <= 0 && seconds <= 0)
        {
            SceneManager.LoadScene("SampleScene");

        }
    }

    IEnumerator Grace()
    {
        yield return new WaitForSeconds(15);
        gracePeriod = false;
   
    }

    IEnumerator Time()
    {
        
        deduct = false;
        yield return new WaitForSeconds(1);
        seconds -= 1;

        //If seconds are below 10 it adds an extra 0 so it looks normal
        if (seconds < 10)
        {
            timer.GetComponent<TextMeshProUGUI>().text = "" + minutes + ":0" + seconds;
        }
        else
        {
            timer.GetComponent<TextMeshProUGUI>().text = "" + minutes + ":" + seconds;
        }
        //When seconds hit 0 it detracts a minute and goes to 59
        if (seconds == 0)
        {
            minutes -= 1;
            yield return new WaitForSeconds(1);
            seconds = 59;
            timer.GetComponent<TextMeshProUGUI>().text = "" + minutes + ":" + seconds;

        }
        deduct = true;
        
    }
}
