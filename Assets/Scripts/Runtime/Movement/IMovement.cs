using UnityEngine;

namespace HumansVsAliens.Model
{
    public interface IMovement
    {
        Transform Transform { get; }

        void Move(Vector3 direction);
    }
}