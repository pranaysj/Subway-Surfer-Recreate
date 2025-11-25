using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Entities
{
    public class TrackSpawnMarker : GenericSingletone<TrackSpawnMarker>, ITrackSpawnMarker
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
                float xPosition = i-2;
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

        public List<TrackSpawnData> GetTrackSpawnData()
        {
            if (trackSpawnDataList.Count == 0)
                Debug.LogWarning("Track Spawn Data List is empty.");
            return trackSpawnDataList;
        }
    }

    public struct TrackSpawnData
    {
        public TrackId track;
        public TrackState state;
        public float xPosition;
        public Vector3 lastSpawnPositon;
    }
}