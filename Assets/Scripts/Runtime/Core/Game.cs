using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using Network = HumansVsAliens.Networking.Network;
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
        
        private IGameLoop _gameLoop;

        private void Start()
        {
            GameConfigurationSave gameConfiguration = SaveStorages.GameConfiguration.Load();
            _gameLoop = new StandardGameLoop();
            INetwork network = new Network();
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create(out IInvulnerability invulnerability);
            ICharacterStatistics statistics = _statisticsFactory.Create();
            IPlayer player = new Player(character);
            IGameLoopObject killsStreak = new KillsStreak(enemiesWorld, _killsStreakView, character.Health);
            _enemyFactories.Init(_gameLoop, statistics);
            _wavesLoopFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            IWavesLoop wavesLoop = gameConfiguration.WavesAreInfinite ? _wavesLoopFactory.Create() : _wavesLoopFactory.CreateTemporary(gameConfiguration.WavesCount);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);
            IChestsLoop chestsLoop = new ChestsLoop(wavesLoop, _chestFactory);
            IGameLoopObject victory = new Victory(wavesLoop, _victoryView);
            
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
            
            if (network.IsMasterClient)
                new PrepareGameCommand(wavesLoop, _wavesView).Execute();
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}