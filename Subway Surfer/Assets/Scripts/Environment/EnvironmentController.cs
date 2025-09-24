using Entities;
using Environment.Track;
using Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.TerrainTools;
using Utilities;

namespace Environment
{
    public class EnvironmentController
    {
        List<TrackSpawnData> markerList;
        private TrackPool trackPool;
        private int zOffsetSpawnPosition = 3;
        private float zPosition = -2.0f;

        public EnvironmentController(List<TrackSpawnData> markerList, TrackPool trackPool)
        {
            this.markerList = markerList;
            this.trackPool = trackPool;
            
            TrackEventManager.OnTrackRecycledOnce += HandleTrackRecycled;

            SpawnInitialTrack();
        }


        private void SpawnInitialTrack()
        {
            for (int i = 0; i < markerList.Count; i++)
            {

                var marker = markerList[i];
            
                if (marker.state != TrackState.Active)
                    continue;

                Vector3 nextSpawnPosition = new Vector3(marker.xPosition, 0f, zPosition);
                for (int j = 0; j < 20; j++)
                {
                    var track = trackPool.GetTrack();
                    var t = track.GetTrack();
                    t.transform.position = nextSpawnPosition;
                    nextSpawnPosition.z += zOffsetSpawnPosition;
                }
                nextSpawnPosition.z -= zOffsetSpawnPosition;
                marker.lastSpawnPositon = nextSpawnPosition;
                markerList[i] = marker;
            }
        }

        private void HandleTrackRecycled(TrackController recycledTrack)
        {
            for (int i = 0; i < markerList.Count; i++)
            {
                var marker = markerList[i];
                if (marker.state != TrackState.Active)
                    continue;

                var track = trackPool.GetTrack();
                var t = track.GetTrack();

                Debug.Log("Spawn Track at: " + marker.lastSpawnPositon);
                t.transform.position = marker.lastSpawnPositon;
                t.gameObject.SetActive(true);
            }
        }

        ~EnvironmentController()
        {
            TrackEventManager.OnTrackRecycledOnce -= HandleTrackRecycled;
        }
    }
}
