using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using Photon.Pun;
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

        private IGameLoop _gameLoop;

        private void Start()
        {
            _gameLoop = new StandardGameLoop();
            var enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            ICharacterStatistics statistics = _statisticsFactory.Create();
            IGameLoopObject player = new Player(character);
            _enemyWavesFactory.Init(enemiesWorld, character, _gameLoop, statistics);
            var timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IEnemyWavesLoop enemyWavesLoop = new EnemyWavesLoop(_enemyWavesFactory.Create(), timerBetweenWaves);
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyWavesLoop,
                enemyCounter
            }));

            InitLoots(character);
            _server.SendCommand(new PrepareGameCommand(enemyWavesLoop, _enemyWavesView));
        }

        private void InitLoots(ICharacter character)
        {
            FindObjectsOfType<WeaponLoot>().ForEach(loot => loot.Init(character));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
            Debug.Log($"Players Count: {PhotonNetwork.PlayerList.Length}");
        }
    }
}