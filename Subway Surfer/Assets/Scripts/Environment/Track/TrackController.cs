using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
namespace Environment.Track
{
    public class TrackController
    {
        public GameObject track;
        private TrackView trackView;

        public static event Action<TrackController> OnTrackRecycled;

        public TrackController(EnvironmentData envData)
        {
            track = GameObject.Instantiate(envData.environmentPrefab);
            trackView = track.GetComponent<TrackView>();
            trackView.SetController(this);
            
        }

        public GameObject GetTrack()
        {
            return track;
        }

        public void UpdateTrackMotion()
        {
            track.transform.Translate(Vector3.back * Time.deltaTime * 2);
        }


        public void RecycleTrack()
        {
            ServiceLocator.GetService<EnvironmentService>().GetTrackPool().ReturnItem(this);
            track.gameObject.SetActive(false);
            OnTrackRecycled?.Invoke(this); // Notify listeners
        }

    }
}
