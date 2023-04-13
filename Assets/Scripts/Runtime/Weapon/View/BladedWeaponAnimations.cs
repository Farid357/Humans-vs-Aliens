using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class BladedWeaponAnimations : MonoBehaviour
    {
        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public async Task PlayHit()
        {
            //TODO ANimation
        }
    }
}