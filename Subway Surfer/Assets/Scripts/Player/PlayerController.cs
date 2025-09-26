using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerController
    {
        private PlayerScriptableObject playerScriptableObject;
        private GameObject gameObject;
        public PlayerView playerView;
        private IStateMachine stateMachine;


        public PlayerController(PlayerScriptableObject playerScriptableObject, IStateMachine playerStateMachine)
        {
            this.playerScriptableObject = playerScriptableObject;
            this.stateMachine = playerStateMachine;
            InitializeView();
        }

        public void InitializeStateMachine()
        {
            stateMachine.ChangeState(new RunState(stateMachine));
        }

        private void InitializeView()
        {
            gameObject = GameObject.Instantiate(playerScriptableObject.playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            playerView = gameObject.GetComponent<PlayerView>();
            playerView.SetController(this);
        }

        public void Update()
        {
            stateMachine.Update();
        }

        public GameObject PlayerGameObject()
        {
            return gameObject;

        }
    }
}
