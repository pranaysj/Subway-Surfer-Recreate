using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    private TrackSpawnMarker trackSpawnMarker;
    private List<Vector3> lanes = new List<Vector3>();
    public GameObject coinPrefab;

    public static CoinsSpawn Instance { get; private set; }
    int laneNxtXPos;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        trackSpawnMarker = TrackSpawnMarker.Instance;
        GetLaneXPosition();

        StartCoroutine(SpawnCoinRoutine());
        StartCoroutine(ChangeLaneRoutine());
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
    IEnumerator ChangeLaneRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            ChangeLane(laneNxtXPos);
        }
    }
    private void SpawnCoins()
    {
        Vector3 spawnPosition = lanes[laneNxtXPos] + new Vector3(0, 0.5f, 50);

        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        coin.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        coin.GetComponent<Renderer>().material.color = Color.yellow;

    }

    public void ChangeLane(float laneX)
    {
        Vector3 next = new Vector3(laneX, 0, 0);

        if (lanes.Contains(next))
        {
            var nxt1 = laneX + 2;
            var lNxtPos = new Vector3(nxt1, 0, 0);
            if (lanes.Contains(lNxtPos))
            {
                laneNxtXPos = lanes.IndexOf(lNxtPos);
            }
            else
            {
                var prev = laneX - 2;
                var lPrevPos = new Vector3(prev, 0, 0);
                if (lanes.Contains(lPrevPos))
                {
                    laneNxtXPos = lanes.IndexOf(lPrevPos);
                }
            }
        }
    }
}
