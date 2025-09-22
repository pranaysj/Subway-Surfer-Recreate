using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class TrackSpawnMarker : GenericSingletone<TrackSpawnMarker>
{
    private List<TrackSpawnData> trackSpawnDataList = new List<TrackSpawnData>();

    public override void Awake()
    {
        base.Awake();
        int totalTrack = Enum.GetNames(typeof(TrackId)).Length;
        for (int i = 0; i < totalTrack; i++)
        {
            TrackId track = GetTrackId(i);
            TrackState state = GetTrackState(i);
            float xPosition = i / 2.0f;
            trackSpawnDataList.Add(new TrackSpawnData
            {
                track = track,
                state = state,
                xPosition = xPosition
            });

        }
    }

    private TrackState GetTrackState(int i)
    {
        return (i % 2 == 0) ? TrackState.Active : TrackState.Inactive;
    }

    private TrackId GetTrackId(int i)
    {
        return (TrackId)i;
    }

    public List<TrackSpawnData> GetTrackSpawnDatas()
    {
        return trackSpawnDataList;
    }
}

public struct TrackSpawnData
{
    public TrackId track;
    public TrackState state;
    public float xPosition;
}
