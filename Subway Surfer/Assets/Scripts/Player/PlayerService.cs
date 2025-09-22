using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerService
    {
        private PlayerController playerController;

        public PlayerService(PlayerScriptableObject playerScriptableObject)
        {
            playerController = new PlayerController(playerScriptableObject);
        }
    }
}