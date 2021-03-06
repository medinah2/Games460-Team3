﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
  pedestrianController controller;
  public Waypoint currentWaypoint;


  int direction;

  private void Awake(){
    controller = GetComponent<pedestrianController>();
  }
    // Start is called before the first frame update
    void Start()
    {
      direction = Mathf.RoundToInt(Random.Range(0f, 1f));

      controller.SetDestination((currentWaypoint.GetPosition()-new Vector3(0f, 1.19f, 0f)));
      // Debug.Log(currentWaypoint.GetPosition()-new Vector3(0f, 1.19f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!PedestrianAI.night)
        {
            if (controller.reachedDestination)
            {

                bool shouldBranch = false;

                if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
                {
                    shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
                }

                if (shouldBranch)
                {
                    currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
                }
                else
                {
                    if (direction == 0)
                    {
                        if (currentWaypoint.nextWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.previousWaypoint;
                            direction = 1;
                        }

                    }
                    else if (direction == 1)
                    {

                        if (currentWaypoint.previousWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.previousWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                            direction = 0;
                        }

                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                }

                controller.SetDestination((currentWaypoint.GetPosition() - new Vector3(0f, 1.19f, 0f)));
            }
        }



    }
}
