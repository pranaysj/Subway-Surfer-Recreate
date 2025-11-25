using Entities;
using Environment;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace Main
{
    public class GameService : GenericSingletone<GameService>
    {
        [SerializeField] private PlayerScriptableObject playerScriptableObject;
        [SerializeField] private EnvironmentScriptableObject environmentScriptableObject;
        public EnvironmentView envView;

        private PlayerService playerService;
        private EnvironmentService environmentService;

        public override void Awake()
        {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
            environmentService = new EnvironmentService(environmentScriptableObject, TrackSpawnMarker.Instance);
            RegisterServices();

        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterService<PlayerService>(playerService);
            ServiceLocator.RegisterService<EnvironmentService>(environmentService);
        }

        private void Update()
        {
        }
    }
}