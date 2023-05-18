using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IBladedWeaponFactory
    {
        IBladedWeapon Create(Transform parent);
    }
}