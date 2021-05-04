using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evidenceSpawnerScript : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    public Vector3 randomPos1;

    public Transform evidenceSpawn1;
    public Transform evidenceSpawn2;
    public Transform evidenceSpawn3;
    public Transform evidenceSpawn4;
    public Transform evidenceSpawn5;
    public Transform evidenceSpawn6;
    public Transform evidenceSpawn7;
    public Transform evidenceSpawn8;
    public Transform evidenceSpawn9;
    public Transform evidenceSpawn10;
    public Transform evidenceSpawn11;
    public Transform evidenceSpawn12;
    public Transform evidenceSpawn13;
    public Transform evidenceSpawn14;
    public Transform evidenceSpawn15;
    public Transform evidenceSpawn16;
    public Transform evidenceSpawn17;
    public Transform evidenceSpawn18;
    public Transform evidenceSpawn19;
    public Transform evidenceSpawn20;
    public Transform evidenceSpawn21;
    public Transform evidenceSpawn22;
    public Transform evidenceSpawn23;
    public Transform evidenceSpawn24;
    public Transform evidenceSpawn25;
    public Transform evidenceSpawn26;
    public Transform evidenceSpawn27;
    public Transform evidenceSpawn28;
    public Transform evidenceSpawn29;
    public Transform evidenceSpawn30;
    public Transform evidenceSpawn31;
    public Transform evidenceSpawn32;

    public Transform nullPos;

    public int evidenceCounter;
    Vector3[] spawnPositions = new Vector3[32];


    // y val must always = 2.5 for all spawned prefabs

    void Start()
    {

    spawnPositions[0] = evidenceSpawn1.transform.position;
    spawnPositions[1] = evidenceSpawn2.transform.position;
    spawnPositions[2] = evidenceSpawn3.transform.position;
    spawnPositions[3] = evidenceSpawn4.transform.position;
    spawnPositions[4] = evidenceSpawn5.transform.position;
    spawnPositions[5] = evidenceSpawn6.transform.position;
    spawnPositions[6] = evidenceSpawn7.transform.position;
    spawnPositions[7] = evidenceSpawn8.transform.position;
    spawnPositions[8] = evidenceSpawn9.transform.position;
    spawnPositions[9] = evidenceSpawn10.transform.position;
    spawnPositions[10] = evidenceSpawn11.transform.position;
    spawnPositions[11] = evidenceSpawn12.transform.position;
    spawnPositions[12] = evidenceSpawn13.transform.position;
    spawnPositions[13] = evidenceSpawn14.transform.position;
    spawnPositions[14] = evidenceSpawn15.transform.position;
    spawnPositions[15] = evidenceSpawn16.transform.position;
    spawnPositions[16] = evidenceSpawn17.transform.position;
    spawnPositions[17] = evidenceSpawn18.transform.position;
    spawnPositions[18] = evidenceSpawn19.transform.position;
    spawnPositions[19] = evidenceSpawn20.transform.position;
    spawnPositions[20] = evidenceSpawn21.transform.position;
    spawnPositions[21] = evidenceSpawn22.transform.position;
    spawnPositions[22] = evidenceSpawn23.transform.position;
    spawnPositions[23] = evidenceSpawn24.transform.position;
    spawnPositions[24] = evidenceSpawn25.transform.position;
    spawnPositions[25] = evidenceSpawn26.transform.position;
    spawnPositions[26] = evidenceSpawn27.transform.position;
    spawnPositions[27] = evidenceSpawn28.transform.position;
    spawnPositions[28] = evidenceSpawn29.transform.position;
    spawnPositions[29] = evidenceSpawn30.transform.position;
    spawnPositions[30] = evidenceSpawn31.transform.position;
    spawnPositions[31] = evidenceSpawn32.transform.position;



        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

     void SpawnObject() {
       while (evidenceCounter != 10) {
          int randomNum = Random.Range(0,31);
          int temp = Random.Range(0,4);

          if (spawnPositions[randomNum] != nullPos.transform.position) {

            if(temp == 0){
              Instantiate(prefab1, spawnPositions[randomNum], Quaternion.identity);
            }else if(temp == 1){
              Instantiate(prefab1, spawnPositions[randomNum], Quaternion.identity);
            }else if(temp == 2){
              Instantiate(prefab1, spawnPositions[randomNum], Quaternion.identity);
            }else{
              Instantiate(prefab1, spawnPositions[randomNum], Quaternion.identity);
            }

            // Instantiate(prefab1, spawnPositions[randomNum], Quaternion.identity);
            spawnPositions[randomNum] = nullPos.transform.position;
            evidenceCounter++;
          }

        }
      }

}
