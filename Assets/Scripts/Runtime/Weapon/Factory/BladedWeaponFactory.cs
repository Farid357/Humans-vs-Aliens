using System;
using HumansVsAliens.Model;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackRadius = 2.25f;

        public IBladedWeapon Create(Transform parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            
            BladedWeaponView view = PhotonNetwork.Instantiate(_prefab.name, _spawnPoint.position, Quaternion.identity).GetComponent<BladedWeaponView>();
            view.transform.SetParent(parent);
            view.Enable();
            return new BladedWeapon(view, _damage, _attackRadius, _layerMask);
        }
    }
}