using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private PlayerScriptableObject playerScriptableObject;
        private PlayerView playerView;
        private GameObject gm;

        public PlayerController(PlayerScriptableObject playerScriptableObject)
        {
            this.playerScriptableObject = playerScriptableObject;
            InitializeView();
        }

        private void InitializeView()
        {
            gm = UnityEngine.Object.Instantiate(playerScriptableObject.playerPrefab, Vector3.up, Quaternion.identity);
            playerView = gm.GetComponent<PlayerView>();
            playerView.SetController(this);
        }
    }
}