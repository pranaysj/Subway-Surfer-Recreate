using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;  

        internal void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void Update()
        {
            playerController?.Update();
            Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red);
        }

        public Transform Transform => transform;
    }
}