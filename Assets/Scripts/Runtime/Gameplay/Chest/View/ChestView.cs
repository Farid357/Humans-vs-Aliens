using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class ChestView : MonoBehaviour, IChestView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _openSound;
        
        private readonly int _openAnimationId = Animator.StringToHash("Open");

        public bool IsActive { get; private set; } = true;

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
            _audioSource.PlayOneShot(_openSound);
            Destroy(gameObject, _openSound.length);
        }

        public void Destroy()
        {
            IsActive = false;
            Destroy(gameObject);
        }
    }
}