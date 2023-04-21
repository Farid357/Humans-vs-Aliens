using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class BladedWeaponAnimations : MonoBehaviour
    {
        private Animator _animator;

        private readonly string[] _hits = new string[]
        {
            "Attack_01",
            "Attack_02"
        };

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public async Task PlayHit()
        {
            _animator.Play("Attack_02");
            
        }
    }
}