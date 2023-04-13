using HumansVsAliens.Model;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _createTransform;
        [SerializeField] private int _damage = 10;

        public IBladedWeapon Create()
        {
            IBladedWeaponView view = Instantiate(_prefab, _createTransform.position, Quaternion.identity, _parent);
            view.Enable();
            return new BladedWeapon(view, _damage);
        }
    }
}