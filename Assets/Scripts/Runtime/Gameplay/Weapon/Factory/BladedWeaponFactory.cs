using System;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackRadius = 2.25f;

        public IBladedWeapon Create(Transform spawnPoint)
        {
            if (spawnPoint == null)
                throw new ArgumentNullException(nameof(spawnPoint));
            
            BladedWeaponView view = PhotonNetwork.Instantiate(_prefab.name, spawnPoint.position, _prefab.transform.rotation).GetComponent<BladedWeaponView>();
            view.transform.SetParent(spawnPoint);
            return new BladedWeapon(view, _damage, _attackRadius, _layerMask);
        }
    }
}