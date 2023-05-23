using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestFactory : MonoBehaviour, IChestFactory
    {
        [SerializeField] private ChestView _chestPrefab;
        [SerializeField] private Transform _centerOfMap;

        public IChest Create()
        {
            IChestView view = PhotonNetwork.Instantiate(_chestPrefab.name, _centerOfMap.position, Quaternion.identity).GetComponent<ChestView>();
            return new Chest(view, new FakeReward());
        }
    }
}