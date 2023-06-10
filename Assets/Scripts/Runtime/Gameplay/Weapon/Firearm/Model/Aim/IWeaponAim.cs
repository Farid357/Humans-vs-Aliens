using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IWeaponAim
    {
        Vector3 ShootDirection { get; }
    }
}