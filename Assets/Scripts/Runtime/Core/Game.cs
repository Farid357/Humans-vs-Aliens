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
        [SerializeField] private WavesFactory _wavesFactory;
        [SerializeField] private EnemyCounterView _enemyCounterView;
        [SerializeField] private TimerBetweenWavesView _timerBetweenWavesView;
        [SerializeField] private WavesView _wavesView;
        [SerializeField] private HealBonusFactory _healBonusFactory;
        [SerializeField] private EnemyFactories _enemyFactories;
        [SerializeField] private KillsStreakView _killsStreakView;
        [SerializeField] private ChestFactory _chestFactory;
        
        private IGameLoop _gameLoop;

        private void Start()
        {
            _gameLoop = new StandardGameLoop();
            INetwork network = new Network();
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create(out IInvulnerability invulnerability);
            ICharacterStatistics statistics = _statisticsFactory.Create();
            IPlayer player = new Player(character);
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IGameLoopObject killsStreak = new KillsStreak(enemiesWorld, _killsStreakView, character.Health);
            _enemyFactories.Init(_gameLoop, statistics);
            _wavesFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            IWavesLoop wavesLoop = new WavesLoop(_wavesFactory.Create(), timerBetweenWaves);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);
            IChestLoop chestLoop = new ChestLoop(wavesLoop, _chestFactory);
            IGameLoopObject autoHeal = new AutoHeal(wavesLoop, character.Health);
            
            IBonusLoop bonusLoop = new BonusLoop(new List<IBonusFactory>
            {
                _healBonusFactory
            });

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                wavesLoop,
                enemyCounter,
                killsStreak,
                chestLoop,
                autoHeal,
                bonusLoop
            }));

            if (network.IsMasterClient)
                new PrepareGameCommand(wavesLoop, _wavesView).Execute();
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}