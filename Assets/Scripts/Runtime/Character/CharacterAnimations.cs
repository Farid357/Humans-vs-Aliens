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

        public async UniTask PlayAttack()
        {
            _animator.Play(_attacks.GetRandom());
            double playSeconds = _animator.GetCurrentAnimatorStateInfo(0).length;
            await UniTask.Delay(TimeSpan.FromSeconds(playSeconds));
        }
    }
}