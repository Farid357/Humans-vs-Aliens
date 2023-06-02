using System;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestFactory : MonoBehaviour, IChestFactory
    {
        [SerializeField] private ChestWithView[] _chestPrefabs;
        [SerializeField] private Transform _centerOfMap;
        
        private IRewardFactory _rewardFactory;

        public void Init(IRewardFactory rewardFactory)
        {
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
        }
        
        public IChestWithView Create()
        {
            ChestWithView chest = Instantiate(_chestPrefabs.GetRandom(), _centerOfMap.position, Quaternion.identity);
            IReward reward = _rewardFactory.Create();
            chest.Init(new Chest(reward));
            return chest;
        }
    }
}