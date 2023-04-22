using System;
using Cysharp.Threading.Tasks;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterAnimations : MonoBehaviour, ICharacterAnimations
    {
        private Animator _animator;
        private UniTask _attackTask = UniTask.CompletedTask;

        public bool IsPlayingAttack => !_attackTask.AsTask().IsCompleted;

        private readonly string[] _attacks = new string[]
        {
            "Attack_01",
            "Attack_02"
        };

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.Play("Death");
        }

        public void PlayGetHit()
        {
            _animator.Play("Get Hit");
        }

        public void PlayAttack()
        {
            if (IsPlayingAttack)
                throw new InvalidOperationException($"Attack is already playing!");
            
            _animator.Play(_attacks.GetRandom());
            double playSeconds = _animator.GetCurrentAnimatorStateInfo(0).length;
            _attackTask = UniTask.Delay(TimeSpan.FromSeconds(playSeconds));
        }
    }
}