using HumansVsAliens.Model;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public interface IBladedWeaponFactory
    {
        IBladedWeapon Create(Transform parent);
    }
}