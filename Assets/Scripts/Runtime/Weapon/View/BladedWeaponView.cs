using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
        private IAttackAnimation _animations;
        private UniTask _hitTask = UniTask.CompletedTask;

        public bool IsHitting => !_hitTask.AsTask().IsCompleted;
        
        public Vector3 Position => transform.position;
      
        public bool IsActive => gameObject.activeInHierarchy;

        public void Init(IAttackAnimation animations)
        {
            _animations = animations ?? throw new ArgumentNullException(nameof(animations));
        }
        
        public void Hit()
        {
            if (IsHitting)
                throw new Exception($"View is already hitting!");
            
            _hitTask = _animations.PlayAttack();
        }

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