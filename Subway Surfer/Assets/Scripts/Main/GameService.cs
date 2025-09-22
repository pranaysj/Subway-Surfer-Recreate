using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;
using Player;

namespace Main
{
    public class GameService : GenericSingletone<GameService>
    {
        [SerializeField] private PlayerScriptableObject playerScriptableObject;
        private PlayerService playerService;

        public override void Awake()
        {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
            RegisterServices();
        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterService<PlayerService>(playerService);
        }
    }
}