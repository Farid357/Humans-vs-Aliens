using System.Collections.Generic;
using HumansVsAliens.Factory;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Model;
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
        [SerializeField] private ScoreFactory _scoreFactory;
        [SerializeField] private EnemyWavesFactory _enemyWavesFactory;
        [SerializeField] private EnemyCounterView _enemyCounterView;
        [SerializeField] private TimerBetweenWavesView _timerBetweenWavesView;
        [SerializeField] private EnemyWavesView _enemyWavesView;

        private IGameLoop _gameLoop;

        private void Awake()
        {
            _gameLoop = new StandardGameLoop();
            var enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            IScore score = _scoreFactory.Create();
            IGameLoopObject player = new Player(character);
            _enemyWavesFactory.Init(enemiesWorld, character);
            var timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IEnemyWavesLoop enemyWavesLoop = new EnemyWavesLoop(_enemyWavesFactory.Create(), timerBetweenWaves);
            IServer server = new Server();
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyWavesLoop,
                enemiesWorld,
                timerBetweenWaves,
                enemyCounter
            }));

            InitLoots(character);
            server.SendCommandToClients(new PrepareGameCommand(enemyWavesLoop, _enemyWavesView));
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