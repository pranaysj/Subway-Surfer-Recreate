using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnvironmentController
{
    private List<EnvironmentView> trackSpawnsList = new List<EnvironmentView>();
    List<TrackSpawnData> markerList;
    private EnvironmentScriptableObject environmentSO;


    public EnvironmentController(EnvironmentScriptableObject environmentSO)
    {
        this.environmentSO = environmentSO;
        InitializeTrackMarker();
        CreateTrack();
    }

    private void CreateTrack()
    {
        EnvironmentData config = GetEnvironmentConfig(EnvironmentType.Track);
        if(config == null)
        {
            Debug.LogWarning("No environment config found for Track type.");
            return;
        }

        foreach (TrackSpawnData data in markerList)
        {
            Vector3 position = new Vector3(data.xPosition, 0, 0);
            GameObject obj = GameObject.Instantiate(config.environmentPrefab, position, Quaternion.identity);
            EnvironmentView view = obj.GetComponent<EnvironmentView>();

            if(view == null)
            {
                Debug.LogWarning("Environment prefab does not have an EnvironmentView component.");
                continue;
            }

            trackSpawnsList.Add(view);
        }
    }

    private EnvironmentData GetEnvironmentConfig(EnvironmentType trackType)
    {
        return environmentSO.DataList?.Find(type => type.environmentType == trackType);
    }

    private void InitializeTrackMarker()
    {
        markerList = TrackSpawnMarker.Instance.GetTrackSpawnDatas();
        if (markerList == null)
        {
            Debug.LogWarning("No track spawn data found.");
            return;
        }

    }
}
