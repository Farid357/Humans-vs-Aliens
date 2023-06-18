using Network = HumansVsAliens.Networking.Network;
using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private CharacterStatisticsFactory _statisticsFactory;
        [SerializeField] private EnemyCounterView _enemyCounterView;
        [SerializeField] private WavesView _wavesView;
        [SerializeField] private HealBonusFactory _healBonusFactory;
        [SerializeField] private ChestBonusFactory _chestBonusFactory;
        [SerializeField] private EnemyFactories _enemyFactories;
        [SerializeField] private KillsStreakView _killsStreakView;
        [SerializeField] private ChestFactory _chestFactory;
        [SerializeField] private WavesLoopFactory _wavesLoopFactory;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private ShopFactory _shopFactory;
        [SerializeField] private CheatsConsoleFactory _cheatsConsoleFactory;
        [SerializeField] private Leaderboard _leaderboard;

        private IGameLoopObjects _gameLoop;
        private INetwork _network;

        private void Start()
        {
            Application.targetFrameRate = 60;

            _gameLoop = new GameLoopObjects();
            _network = new Network();
            
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            ICharacterStatistics statistics = _statisticsFactory.Create(_network);
            IPlayer player = new Player(character);
            IGameLoopObject killsStreak = new TemporaryKillStreak(new KillsStreak(enemiesWorld, _killsStreakView, character.Health));
          
            _leaderboard.Init(_network);
            _chestFactory.Init(new ChestRewardFactory(statistics));
            _enemyFactories.Init(_gameLoop, statistics);
            _wavesLoopFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            
            IGameConfigurationSave gameConfiguration = _network.GameConfiguration();
            IWavesLoop wavesLoop = _wavesLoopFactory.Create(gameConfiguration);
            IEnemyCounter enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);
            IChestsLoop chestsLoop = new ChestsLoop(wavesLoop, _chestFactory);

            if (gameConfiguration.AutoHealIsOn)
                _gameLoop.Add(new AutoHeal(wavesLoop, character.Health));

            if (gameConfiguration.CheatsAreEnabled)
                _cheatsConsoleFactory.Create(character, statistics);

            _shopFactory.Create(statistics.Wallet, character, enemiesWorld, wavesLoop);

            IBonusesLoop bonusesLoop = new BonusesLoop(new List<IBonusFactory>
            {
                _healBonusFactory,
                _chestBonusFactory
            });

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyCounter,
                killsStreak,
                wavesLoop,
                chestsLoop,
                bonusesLoop
            }));

            if (_network.IsMasterClient)
            {
                IMasterClient masterClient = new MasterClient(_wavesView, wavesLoop, _network);
                _gameLoop.Add(new Victory(wavesLoop, _leaderboard, _victoryView, masterClient));
                masterClient.StartGame();
            }
        }

        private void Update()
        {
            if (_network.PlayerInRoom)
                _gameLoop.Update(Time.deltaTime);
        }
    }
}