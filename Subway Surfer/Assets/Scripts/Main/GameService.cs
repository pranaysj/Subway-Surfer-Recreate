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
        [SerializeField] private EnvironmentScriptableObject environmentScriptableObject;

        private PlayerService playerService;
        private EnvironmentService environmentService;

        public override void Awake()
        {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
            environmentService = new EnvironmentService(environmentScriptableObject);
            RegisterServices();
        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterService<PlayerService>(playerService);
            ServiceLocator.RegisterService<EnvironmentService>(environmentService);
        }
    }
}