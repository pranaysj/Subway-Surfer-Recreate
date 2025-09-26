using Entities;
using Environment.Track;
using Main;
using System;
using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class TrackEventManager
{
    private static bool isInvoking;
    private static float resetDelay = 0.1f; // seconds

    public static event Action<TrackController> OnTrackRecycledOnce;

    public static void RaiseRecycled(TrackController track)
    {
        if (isInvoking) return;

        isInvoking = true;
        OnTrackRecycledOnce?.Invoke(track);

        // Start a timer to reset
        TrackSpawnMarker.Instance.StartCoroutine(ResetAfterDelay());
    }

    private static IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        isInvoking = false;
    }
}