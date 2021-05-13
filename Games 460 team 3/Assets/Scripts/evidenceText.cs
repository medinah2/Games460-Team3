using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evidenceText : MonoBehaviour
{
    Text score;
    void Start()
    {
      score = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
      score.text = "Evidence Collected: "  + movement.evidenceCollected + "/5";
    }
}
