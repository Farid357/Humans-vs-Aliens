using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackRadius = 2.25f;

        public IBladedWeapon Create()
        {
            BladedWeaponView view = PhotonNetwork.Instantiate(_prefab.name, _spawnPoint.position, _prefab.transform.rotation).GetComponent<BladedWeaponView>();
            view.transform.SetParent(_spawnPoint);
            return new BladedWeapon(view, _damage, _attackRadius);
        }
    }
}