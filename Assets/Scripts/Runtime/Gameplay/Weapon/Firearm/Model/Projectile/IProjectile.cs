using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IProjectile
    {
        void Throw(Vector3 direction);
    }
}