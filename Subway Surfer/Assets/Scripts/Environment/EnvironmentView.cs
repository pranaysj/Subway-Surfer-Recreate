using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Environment
{
    public class EnvironmentView : MonoBehaviour
    {
        private TrackPool trackPool;

        public void SetController(TrackPool trackPool)
        {
            this.trackPool = trackPool;
        }
    }
}
