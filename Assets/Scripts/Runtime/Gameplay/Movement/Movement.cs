using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public abstract class Movement : MonoBehaviour, IMovement
    {
        public abstract Vector3 Position { get; }

        public abstract void Move(Vector3 direction);
    }
}