using System;
using HumansVsAliens.Tools;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestFactory : MonoBehaviour, IChestFactory
    {
        [SerializeField] private ChestWithView[] _chestPrefabs;
        [SerializeField] private ChestWithView[] _networkChestPrefabs;
        [SerializeField] private Transform _centerOfMap;
        
        private IRewardFactory _rewardFactory;

        public void Init(IRewardFactory rewardFactory)
        {
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
        }
        
        public IChestWithView CreateLocal()
        {
            ChestWithView chest = Instantiate(_chestPrefabs.GetRandom(), _centerOfMap.position, Quaternion.identity);
            IReward reward = _rewardFactory.Create();
            chest.Init(new Chest(reward));
            return chest;
        }

        public IChestWithView Create()
        {
            //TODO
            return CreateLocal();
            
            ChestWithView chest = PhotonNetwork.Instantiate(_networkChestPrefabs.GetRandom().name, _centerOfMap.position, Quaternion.identity).GetComponent<ChestWithView>();
            IReward reward = _rewardFactory.Create();
            chest.Init(new Chest(reward));
            return chest;
        }
    }
}