using System;
using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
        [SerializeField] private BladedWeaponAnimations _animations;
        private Task _hitTask = Task.CompletedTask;

        public void Hit()
        {
            if (IsHitting)
                throw new Exception($"View is already hitting!");
            
            _hitTask = _animations.PlayHit();
        }

        public bool IsHitting => !_hitTask.IsCompleted;
        
        public Vector3 Position => transform.position;
      
        public bool IsActive => gameObject.activeInHierarchy;
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}