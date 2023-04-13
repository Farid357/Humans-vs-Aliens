using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
        [SerializeField] private BladedWeaponAnimations _animations;
        
        public Vector3 Position => transform.position;
      
        public bool IsActive => gameObject.activeInHierarchy;
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public async Task Hit()
        {
            await _animations.PlayHit();
        }

    }
}