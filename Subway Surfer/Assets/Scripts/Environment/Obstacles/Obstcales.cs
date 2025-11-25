using Entities;
using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstcales : MonoBehaviour
{
    private TrackSpawnMarker trackSpawnMarker;
    private List<Vector3> lanes = new List<Vector3>();
    public GameObject[] obstacles;


    // Start is called before the first frame update
    void Start()
    {
        trackSpawnMarker = TrackSpawnMarker.Instance;
        GetLaneXPosition();
        StartCoroutine(SpawnRoutine());

    }

    private void SpawnPrimitive()
    {
        bool[] laneBlocked = new bool[3];

        int blockedCount = 0;
        for (int lane = 0; lane < 3; lane++)
        {
            bool shouldSpawn = UnityEngine.Random.value < 0.5f;
            laneBlocked[lane] = shouldSpawn;
            if (shouldSpawn) blockedCount++;
        }

        // Ensure at least 1 free lane
        if (blockedCount == 3)
        {
            int randomLane = UnityEngine.Random.Range(0, 3);
            laneBlocked[randomLane] = false;
            blockedCount--;
        }

        for (int lane = 0; lane < 3; lane++)
        {
            if (laneBlocked[lane])
            {
                Vector3 spawnPosition = lanes[lane] + new Vector3(-0.5f, 0, 55);
                int obstacleIndex = UnityEngine.Random.Range(0, obstacles.Length);
                Instantiate(obstacles[obstacleIndex], spawnPosition, Quaternion.identity);
            }
        }
        
    }


    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(0f, 5f);   // random seconds between 0–5
            yield return new WaitForSeconds(waitTime);

            SpawnPrimitive();
        }
    }

    void GetLaneXPosition()
    {

        List<TrackSpawnData> markerList = trackSpawnMarker.GetTrackSpawnData();
        foreach (var marker in markerList)
        {
            if(marker.state == TrackState.Active)
            {
                lanes.Add(new Vector3(marker.xPosition, 0, 0));
            }
        }
    }
}
