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
        [SerializeField] private int _health = 80;

        private IGameLoopObjectsGroup _gameLoop;
        private IServer _server;
        private IRewardFactory _rewardFactory;

        public void Init(IGameLoopObjectsGroup gameLoop, IRewardFactory rewardFactory, IServer server)
        {
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }
        
        public IEnemy Create(Vector3 position)
        {
            Alien alien = PhotonNetwork.Instantiate(_alienPrefab.name, position, Quaternion.identity).GetComponent<Alien>();
            IHealthView healthView = new AlienHealthView(alien.gameObject);
            IHealth health = new Health(healthView, _health);
            _server.SendCommand(new InitAlienCommand(health, alien));
            IReward reward = _rewardFactory.Create();
            IGameLoopObject killReward = new KillReward(health, reward);
            _gameLoop.Add(killReward);
            return alien;
        }
    }
}