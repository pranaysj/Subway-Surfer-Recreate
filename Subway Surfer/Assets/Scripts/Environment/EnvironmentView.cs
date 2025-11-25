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
        // Start is called before the first frame update
        void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                trackPool.GetTrack();
                Debug.Log(trackPool.Count);
            }
        }
    }
}
