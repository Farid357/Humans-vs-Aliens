using System;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public class HealthSynchronization : MonoBehaviourPun, IHealth, IPunObservable
    {
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public bool IsAlive => _health.IsAlive;

        public int Value => _health.Value;

        public void TakeDamage(int damage) => _health.TakeDamage(damage);

        public void Heal(int heal) => _health.Heal(heal);

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_health.Value);
            }
            
            else
            {
                int health = (int)stream.ReceiveNext();

                if (_health.Value == health)
                    return;
                
                if (_health.Value > health)
                {
                    _health.TakeDamage(_health.Value - health);
                }

                else
                {
                    _health.Heal(health - _health.Value);
                }
            }
        }
    }
}