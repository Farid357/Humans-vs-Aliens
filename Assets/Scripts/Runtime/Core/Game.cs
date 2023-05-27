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
        [SerializeField] private Server _server;
        [SerializeField] private HealBonusFactory _healBonusFactory;
        [SerializeField] private EnemyFactories _enemyFactories;
        [SerializeField] private KillsStreakView _killsStreakView;

        private IGameLoop _gameLoop;

        private void Start()
        {
            _gameLoop = new StandardGameLoop();
            INetwork network = new Network();
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            ICharacterStatistics statistics = _statisticsFactory.Create();
            IGameLoopObject player = new Player(character);
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IGameLoopObject killsStreak = new KillsStreak(enemiesWorld, _killsStreakView, character.Health);
            _enemyFactories.Init(_gameLoop, statistics, _server);
            _wavesFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            IWavesLoop wavesLoop = new WavesLoop(_wavesFactory.Create(), timerBetweenWaves);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);

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
                bonusLoop
            }));

            if (network.IsMasterClient)
                _server.SendCommand(new PrepareGameCommand(wavesLoop, _wavesView));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}