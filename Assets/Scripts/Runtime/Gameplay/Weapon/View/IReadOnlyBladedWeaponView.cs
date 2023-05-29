using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IReadOnlyBladedWeaponView
    {
        bool IsActive { get; }

        Vector3 Position { get; }
        
        IBladedWeaponViewData Data { get; }
        
    }
}