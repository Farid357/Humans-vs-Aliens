using UnityEngine;

namespace HumansVsAliens.Model
{
    [RequireComponent(typeof(Collider))]
    public abstract class Loot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out ICharacter _))
            {
                Pick();
            }
        }

        protected abstract void Pick();
    }
}