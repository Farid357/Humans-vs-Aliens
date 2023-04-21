using UnityEngine;

namespace HumansVsAliens.Model
{
    public abstract class MovementAnimations : MonoBehaviour
    {
        public abstract void PlayMove(Vector3 direction);
    }
}