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
        private EnvironmentView environmentView;

        public EnvironmentController(List<TrackSpawnData> markerList, TrackPool trackPool)
        {
            this.markerList = markerList;
            this.trackPool = trackPool;
            environmentView = GameService.Instance.envView;
            environmentView.SetController(trackPool);

            TrackController.OnTrackRecycled += HandleTrackRecycled;

            //CreateTracks();
            SingleTrackSpawn();
        }


        private void SingleTrackSpawn()
        {
            var marker = markerList[0];
            Vector3 nextSpawnPosition = new Vector3(marker.xPosition, 0f, 0f);
            for (int j = 0; j < 10; j++)
            {
                var track = trackPool.GetTrack();
                var t = track.GetTrack();
                t.transform.position = nextSpawnPosition;
                nextSpawnPosition.z += 3;
            }
            nextSpawnPosition.z -= 3;
            marker.lastSpawnPositon = nextSpawnPosition;
            markerList[0] = marker;
        }

        private void HandleTrackRecycled(TrackController recycledTrack)
        {
            var marker = markerList[0];
            Vector3 nextSpawnPosition = marker.lastSpawnPositon;
            var track = trackPool.GetTrack();
            var t = track.GetTrack();
            t.transform.position = nextSpawnPosition;
            t.gameObject.SetActive(true);
            Debug.Log(t.transform.position);
        }

        ~EnvironmentController()
        {
            TrackController.OnTrackRecycled -= HandleTrackRecycled;
        }

        private void CreateTracks()
        {
            if (trackPool == null)
            {
                Debug.LogWarning("Track pool is not initialized.");
                return;
            }

            for (int i = 0; i < markerList.Count; i++)
            {
                var marker = markerList[i];

                if (marker.state != TrackState.Active) 
                    continue;

                Vector3 nextSpawnPosition = new Vector3(marker.xPosition, 0f, 0f);

                for (int j = 0; j < 5; j++)
                {
                    var track = trackPool.GetTrack();
                    var t = track.GetTrack();
                    t.transform.position = nextSpawnPosition;


                    nextSpawnPosition.z += 3;
                }

                marker.lastSpawnPositon = nextSpawnPosition;
                markerList[i] = marker;
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < markerList.Count; i++)
            {
                var marker = markerList[i];

                if (marker.state != TrackState.Active)
                    continue;

                Vector3 position = marker.lastSpawnPositon;

                var newTrack = trackPool.GetTrack();
                var t = newTrack.GetTrack();
                t.transform.position = position;

            }
        }

        private void Respawn(TrackController track)
        {
            //trackPool.ReturnItem(track);
            Debug.Log(trackPool.Count);

        }

        //Create method in which when onTrackRecycle is invoke, get the trackController return it to trackPool and get the track and position it on lastSpawnPosition of the markerList

    }
}
