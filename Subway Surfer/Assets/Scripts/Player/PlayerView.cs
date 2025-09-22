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
    }
}