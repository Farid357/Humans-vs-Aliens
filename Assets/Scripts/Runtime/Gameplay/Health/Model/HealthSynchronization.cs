using System;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public class HealthSynchronization : MonoBehaviour, IHealth
    {
        private PhotonView _photonView;
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _photonView = GetComponent<PhotonView>();
        }

        public bool IsAlive => _health.IsAlive;

        public int Value => _health.Value;

        public void TakeDamage(int damage)
        {
            _photonView.RPC(nameof(TakeDamageRpc), RpcTarget.All, damage);
        }

        public void Heal(int heal)
        {
            _photonView.RPC(nameof(HealRpc), RpcTarget.All, heal);
        }

        [PunRPC]
        private void TakeDamageRpc(int damage)
        {
            _health.TakeDamage(damage);
        }

        [PunRPC]
        private void HealRpc(int heal)
        {
            _health.Heal(heal);
        }
    }
}