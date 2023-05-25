using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private CharacterStatisticsFactory _statisticsFactory;
        [SerializeField] private EnemyWavesFactory _enemyWavesFactory;
        [SerializeField] private EnemyCounterView _enemyCounterView;
        [SerializeField] private TimerBetweenWavesView _timerBetweenWavesView;
        [SerializeField] private EnemyWavesView _enemyWavesView;
        [SerializeField] private Server _server;
        [SerializeField] private HealBonusFactory _healBonusFactory;
        [SerializeField] private EnemyFactories _enemyFactories;
        
        private IGameLoop _gameLoop;

        private void Start()
        {
            _gameLoop = new StandardGameLoop();
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            ICharacterStatistics statistics = _statisticsFactory.Create();
            IGameLoopObject player = new Player(character);
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            _enemyFactories.Init(character, _gameLoop, statistics, _server);
            _enemyWavesFactory.Init(enemiesWorld, _enemyFactories.Create());
            _healBonusFactory.Init(character.Health);
            IEnemyWavesLoop enemyWavesLoop = new EnemyWavesLoop(_enemyWavesFactory.Create(), timerBetweenWaves);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);

            IBonusLoop bonusLoop = new BonusLoop(new List<IBonusFactory>
            {
                _healBonusFactory
            });
            
            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyWavesLoop,
                enemyCounter,
                bonusLoop
            }));

            _server.SendCommand(new PrepareGameCommand(enemyWavesLoop, _enemyWavesView));
        }
        
        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}