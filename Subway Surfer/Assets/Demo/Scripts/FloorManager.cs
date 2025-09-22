using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject floorSegmentPrefab;
    [SerializeField] private int numberOfSegment;
    [SerializeField] private float segmentLength;
    [SerializeField] private int moveSpeed;

    private List<GameObject> floorSegments = new List<GameObject>();
    private Vector3 nextSpawnLocation;

    void Start()
    {
        nextSpawnLocation = Vector3.zero;
        for (int i = 0; i < numberOfSegment; i++)
        {
            SpawnSegment();
        }
        nextSpawnLocation.z -= segmentLength;
    }

    void Update()
    {
        foreach (GameObject segment in floorSegments)
        {
            segment.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (floorSegments[0].transform.position.z < -segmentLength)
        {
            RecycleSegment();
        }
    }

    void SpawnSegment()
    {
        GameObject segment = Instantiate(floorSegmentPrefab, nextSpawnLocation, Quaternion.identity);
        floorSegments.Add(segment);
        nextSpawnLocation.z += segmentLength;
    }

    void RecycleSegment()
    {
        GameObject segment = floorSegments[0];
        floorSegments.RemoveAt(0);
        segment.transform.position = nextSpawnLocation;
        floorSegments.Add(segment);
    }
}
