using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestFactory : MonoBehaviour, IChestFactory
    {
        [SerializeField] private ChestView[] _chestPrefabs;
        [SerializeField] private Transform _centerOfMap;
        [SerializeField] private ChestRewardFactory _chestRewardFactory;

        public IChest Create()
        {
            //TODO Replace Reward
            IChestView view = Instantiate(_chestPrefabs.GetRandom(), _centerOfMap.position, Quaternion.identity);
            return new Chest(view, new FakeReward());
        }
    }
}