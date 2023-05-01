using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IReadOnlyBladedWeaponView
    {
        Vector3 Position { get; }
        
        IBladedWeaponViewData Data { get; }
        
        bool IsActive { get; }
    }
}