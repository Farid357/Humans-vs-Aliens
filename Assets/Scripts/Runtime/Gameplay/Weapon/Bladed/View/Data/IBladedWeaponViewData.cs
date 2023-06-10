using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IBladedWeaponViewData
    {
        string Name { get; }
        
        Sprite Icon { get; }
    }
}