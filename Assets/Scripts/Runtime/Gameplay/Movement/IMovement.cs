using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IMovement
    {
        Transform Transform { get; }

        void Move(Vector3 direction);
    }
}