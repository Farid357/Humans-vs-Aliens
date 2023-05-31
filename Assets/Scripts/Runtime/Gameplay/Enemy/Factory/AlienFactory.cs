using System;
using HumansVsAliens.GameLoop;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class AlienFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Alien _alienPrefab;
        [SerializeField] private int _health = 80;

        private IGameLoopObjectsGroup _gameLoop;
        private IRewardFactory _rewardFactory;

        public void Init(IGameLoopObjectsGroup gameLoop, IRewardFactory rewardFactory)
        {
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IEnemy Create(Vector3 position)
        {
            Alien alien = PhotonNetwork.Instantiate(_alienPrefab.name, position, Quaternion.identity).GetComponent<Alien>();
            PhotonView photonView = PhotonView.Get(alien);
            photonView.RPC(nameof(alien.Init), RpcTarget.AllBuffered, _health);
            IReward reward = _rewardFactory.Create();
            IGameLoopObject killReward = new RewardForMurder(alien.Health, reward);
            _gameLoop.Add(killReward);
            return alien;
        }
    }
}