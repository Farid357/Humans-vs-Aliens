using UnityEngine;

namespace HumansVsAliens
{
    public interface ICharacterMovement
    {
        bool OnGround { get; }

        void Move(Vector2 direction);

        void Jump();
    }
}