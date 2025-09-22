using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private PlayerScriptableObject playerScriptableObject;
        private PlayerView playerView;

        public PlayerController(PlayerScriptableObject playerScriptableObject)
        {
            this.playerScriptableObject = playerScriptableObject;
            InitializeView();
        }

        private void InitializeView()
        {
            playerView = Object.Instantiate(playerScriptableObject.playerPrefab);
            playerView.SetController(this);
        }
    }
}
