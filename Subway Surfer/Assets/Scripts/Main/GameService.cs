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

        private InputService inputService;
        private IStateMachine playerStateMachine;

        public override void Awake()
        {
            base.Awake();
            inputService = new InputService();
            playerStateMachine = new PlayerStateMachine();
            playerService = new PlayerService(playerScriptableObject, playerStateMachine);
            environmentService = new EnvironmentService(environmentScriptableObject, TrackSpawnMarker.Instance);
            RegisterServices();
            playerService.Initialize();
        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterService<PlayerService>(playerService);
            ServiceLocator.RegisterService<IStateMachine>(playerStateMachine);
            ServiceLocator.RegisterService<EnvironmentService>(environmentService);
            ServiceLocator.RegisterService<InputService>(inputService);
        }
    }
}