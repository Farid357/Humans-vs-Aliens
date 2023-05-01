using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HumansVsAliens.Factory;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Model;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private ScoreFactory _scoreFactory;
        [SerializeField] private EnemyWavesFactory _enemyWavesFactory;
        [SerializeField] private EnemyCounterView _enemyCounterView;

        private IGameLoop _gameLoop;

        private async void Awake()
        {
            _gameLoop = new StandardGameLoop();
            var enemiesWorld = new EnemiesWorld();
            ICharacter character = _characterFactory.Create();
            IScore score = _scoreFactory.Create();
            IGameLoopObject player = new Player(character);
            _enemyWavesFactory.Init(enemiesWorld, character);
            IEnemyWavesLoop enemyWavesLoop = new EnemyWavesLoop(_enemyWavesFactory.Create());
            IServer server = new Server();
            IGameLoopObject enemyCounter = new EnemyCounter(enemiesWorld, _enemyCounterView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                enemyWavesLoop,
                enemiesWorld,
                enemyCounter
            }));
            
            InitLoots(character);
            await UniTask.Delay(3000);
            server.SendCommandToClients(new PrepareGameCommand(enemyWavesLoop));
        }

        private void InitLoots(ICharacter character)
        {
            FindObjectsOfType<WeaponLoot>().ForEach(loot => loot.Init(character));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
            Debug.Log($"Player: {PhotonNetwork.PlayerList.Length}");
        }
    }
}