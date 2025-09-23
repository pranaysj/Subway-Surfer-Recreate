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
        private TrackController trackController;

        public void SetController(TrackController trackController) => this.trackController = trackController;

        void Update()
        {
            trackController?.UpdateTrackMotion();
            
            if (transform.position.z < -3)
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