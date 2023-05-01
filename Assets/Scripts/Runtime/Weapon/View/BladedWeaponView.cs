using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponView : MonoBehaviour, IBladedWeaponView
    {
        [SerializeField] private BladedWeaponViewData _data;
        [SerializeField] private Transform _transform;
        
        public Vector3 Position => _transform.position;
        
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Position, transform.forward);
        }
    }
}