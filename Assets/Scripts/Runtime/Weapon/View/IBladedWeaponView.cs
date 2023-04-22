using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IBladedWeaponView
    {
        Vector3 Position { get; }

        IBladedWeaponViewData Data { get; }
        
        bool IsActive { get; }

        void Enable();

        void Disable();
    }
}