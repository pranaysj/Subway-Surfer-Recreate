using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerService
    {
        private PlayerController playerController;

        public PlayerService(PlayerScriptableObject playerScriptableObject, IStateMachine playerStateMachine)
        {
            playerController = new PlayerController(playerScriptableObject, playerStateMachine);
        }

        public void Initialize()
        {
            playerController.InitializeStateMachine(); // Safe to call now
        }


        public PlayerController GetPlayerController()
        {
            return playerController;
        }
    }
}