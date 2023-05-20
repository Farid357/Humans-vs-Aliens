using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class AlienFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Alien _alienPrefab;
        [SerializeField] private EnemyRewardFactory _rewardFactory;
        [SerializeField] private int _health = 80;

        private IReadOnlyCharacter _character;
        private IGameLoopObjectsGroup _gameLoop;
        private IServer _server;

        public void Init(IReadOnlyCharacter character, IGameLoopObjectsGroup gameLoop, ICharacterStatistics statistics, IServer server)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _server = server ?? throw new ArgumentNullException(nameof(server));
            _rewardFactory.Init(statistics.Wallet, statistics.Score);
        }
        
        public IEnemy Create(Vector3 position)
        {
            Alien alien = PhotonNetwork.Instantiate(_alienPrefab.name, position, Quaternion.identity).GetComponent<Alien>();
            IHealthView healthView = new AlienHealthView(alien.gameObject);
            IHealth health = new Health(healthView, _health);
            _server.SendCommand(new InitAlienCommand(_character, health, alien));
            IReward reward = _rewardFactory.Create();
            IGameLoopObject killReward = new KillReward(health, reward);
            _gameLoop.Add(killReward);
            return alien;
        }
    }
}