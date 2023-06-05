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
        [SerializeField] private EnemyFactories _enemyFactories;
        [SerializeField] private KillsStreakView _killsStreakView;
        [SerializeField] private ChestFactory _chestFactory;
        [SerializeField] private WavesLoopFactory _wavesLoopFactory;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private ShopFactory _shopFactory;
        [SerializeField] private CheatsConsoleFactory _cheatsConsoleFactory;
        [SerializeField] private Leaderboard _leaderboard;
        
        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();

        private void Start()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            
            INetwork network = new Network();
            _leaderboard.Init(network);
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create(out IInvulnerability invulnerability);
            ICharacterStatistics statistics = _statisticsFactory.Create(network);
            IPlayer player = new LocalPlayer(character);
            IGameLoopObject killsStreak = new TemporaryKillStreak(new KillsStreak(enemiesWorld, _killsStreakView, character.Health));
            _enemyFactories.Init(_gameLoop, statistics);
            _wavesLoopFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            _chestFactory.Init(new ChestRewardFactory(statistics));
            IGameConfigurationSave gameConfiguration = network.GameConfiguration();
            IWavesLoop wavesLoop = gameConfiguration.WavesAreInfinite ? _wavesLoopFactory.CreateInfinite() : _wavesLoopFactory.Create(gameConfiguration.WavesCount);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);
            IChestsLoop chestsLoop = new ChestsLoop(wavesLoop, _chestFactory);
            IGameLoopObject victory = new Victory(wavesLoop, _leaderboard, _victoryView);
            
            IBonusesLoop bonusesLoop = new BonusesLoop(new List<IBonusFactory>
            {
                _healBonusFactory
            });

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyCounter,
                killsStreak,
                victory,
                wavesLoop,
                chestsLoop,
                bonusesLoop
            }));

            if(gameConfiguration.AutoHealIsOn)
                _gameLoop.Add(new AutoHeal(wavesLoop, character.Health));

            if (gameConfiguration.CheatsAreEnabled)
                _cheatsConsoleFactory.Create(character, statistics);
            
            if (network.IsMasterClient)
                new PrepareGameCommand(wavesLoop, _wavesView).Execute();

            _shopFactory.Create(statistics.Wallet, character, enemiesWorld, wavesLoop);
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}