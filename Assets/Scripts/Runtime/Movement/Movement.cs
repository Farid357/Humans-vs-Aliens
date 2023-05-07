using UnityEngine;

namespace HumansVsAliens.Model
{
    public abstract class Movement : MonoBehaviour, IMovement
    {
        public abstract Transform Transform { get; }

        public abstract void Move(Vector3 direction);
    }
}