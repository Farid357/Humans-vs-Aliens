using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public abstract class MovementAnimations : MonoBehaviour
    {
        public abstract void PlayMove(Vector3 direction);
    }
}