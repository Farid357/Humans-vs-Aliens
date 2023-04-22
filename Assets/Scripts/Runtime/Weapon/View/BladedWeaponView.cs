using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
        [SerializeField] private BladedWeaponViewData _data;
        
        public Vector3 Position => transform.position;
        
        public IBladedWeaponViewData Data => _data;

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