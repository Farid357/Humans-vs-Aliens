using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IBladedWeaponView : IBladedWeaponActivityView
    {
        void Hit();
        
        bool IsHitting { get; }
     
        Vector3 Position { get; }
    }
}