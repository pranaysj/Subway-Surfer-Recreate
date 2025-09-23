using Entities;
using System.Collections.Generic;

namespace Environment
{
    public interface ITrackSpawnMarker
    {
        List<TrackSpawnData> GetTrackSpawnData();
    }
}
