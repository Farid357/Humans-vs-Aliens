using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
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
    }
}