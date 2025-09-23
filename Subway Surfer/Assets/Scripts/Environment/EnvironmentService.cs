using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{

    public class EnvironmentService 
    {
        private EnvironmentScriptableObject environmentSO;

        private readonly EnvironmentController environmentController;
        private TrackPool trackPool;

        private List<TrackSpawnData> markerList;


        public EnvironmentService(EnvironmentScriptableObject environmentSO, ITrackSpawnMarker markerLiat)
        {
            this.environmentSO = environmentSO;
            this.markerList = markerLiat.GetTrackSpawnData();

            CreateTrackPool();
            environmentController = new EnvironmentController(markerList, trackPool);
        }

        private void CreateTrackPool()
        {
            EnvironmentData trackData = GetEnvironmentData(EnvironmentType.Track);
            trackPool = new TrackPool(trackData);
        }

        private EnvironmentData GetEnvironmentData(EnvironmentType trackType)
        {
            return environmentSO.DataList?.Find(type => type.environmentType == trackType);
        }

        public TrackPool GetTrackPool() => trackPool;

    }
}