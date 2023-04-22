using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IBladedWeaponView
    {
        Vector3 Position { get; }

        bool IsActive { get; }

        void Enable();

        void Disable();
    }
}