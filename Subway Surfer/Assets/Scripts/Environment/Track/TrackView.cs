using Main;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
namespace Environment.Track
{

    public class TrackView : MonoBehaviour
    {
        [SerializeField] private int speed;
        [Header("Also change offsetSpawnPosition")]
        [SerializeField] private int zOutOfBound;
        private TrackController trackController;

        public void SetController(TrackController trackController) => this.trackController = trackController;

        void Update()
        {
            trackController?.UpdateTrackMotion(speed);
            
            if (transform.position.z < zOutOfBound)
            {
                RecycleTrack();
            }
        }

        void RecycleTrack()
        {
            //Destroy(trackController.track);
            trackController?.RecycleTrack();
        }
    }
}