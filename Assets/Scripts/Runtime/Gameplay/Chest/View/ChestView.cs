using System;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class ChestView : MonoBehaviour, IChestView
    {
        [SerializeField] private Animator _animator;
        
        public async void Open()
        {
            _animator.Play("Open");
            TimeSpan animationLength = TimeSpan.FromSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
            await UniTask.Delay(animationLength);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}