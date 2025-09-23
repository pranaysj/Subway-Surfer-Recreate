using Entities;
using Environment;
using Environment.Track;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPool : GenericObjectPool<TrackController>
{
    private EnvironmentData trackData;

    public TrackPool(EnvironmentData trackData) 
    {
        this.trackData = trackData;
    }

    public TrackController GetTrack() => GetItem<TrackController>();

    protected override TrackController CreateItem<U>() => new TrackController(trackData);
}
