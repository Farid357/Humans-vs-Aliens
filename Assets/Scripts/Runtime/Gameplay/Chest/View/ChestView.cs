using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class ChestView : MonoBehaviour, IChestView
    {
        [SerializeField] private Animator _animator;
        
        private readonly int _openAnimationId = Animator.StringToHash("Open");

        private async void OnEnable()
        {
            _animator.Play(_openAnimationId);
            float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            await UniTask.Delay(TimeSpan.FromSeconds(animationLength));
            _animator.Play("Close");
        }

        public void Open()
        {
            _animator.Play(_openAnimationId);
            float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationLength);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}