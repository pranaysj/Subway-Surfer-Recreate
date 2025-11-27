using Entities;
using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    private TrackSpawnMarker trackSpawnMarker;
    private List<Vector3> lanes = new List<Vector3>();
    public GameObject coinPrefab;

    void Start()
    {
        trackSpawnMarker = TrackSpawnMarker.Instance;
        GetLaneXPosition();
        StartCoroutine(SpawnCoinRoutine());
    }

    private void SpawnCoins()
    {

        Vector3 spawnPosition = lanes[2] + new Vector3(0, 0.5f, 50);
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = spawnPosition;
        coin.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        coin.GetComponent<Renderer>().material.color = Color.yellow;
    }


    void GetLaneXPosition()
    {
        List<TrackSpawnData> markerList = trackSpawnMarker.GetTrackSpawnData();
        foreach (var marker in markerList)
        {
            lanes.Add(new Vector3(marker.xPosition, 0, 0));
        }
    }

    IEnumerator SpawnCoinRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            SpawnCoins();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + "Coin collected!");
    }
}
