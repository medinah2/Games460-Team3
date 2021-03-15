﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created using https://youtu.be/MXCZ-n5VyJc

public class Waypoint : MonoBehaviour
{

public Waypoint previousWaypoint;
public Waypoint nextWaypoint;

[Range(0f, 5f)]
public float width = 3f;

public List<Waypoint> branches = new List<Waypoint>();

[Range(0f, 5f)]
public float branchRatio = 0.5f;

public Vector3 GetPosition(){
  Vector3 minBound = transform.position + transform.right * width / 2f;
  Vector3 maxBound = transform.position - transform.right * width / 2f;

  return Vector3.Lerp(minBound, maxBound, Random.Range(0f,1f));
}

}
