using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public interface IBladedWeapon
    {
        bool CanHit { get; }

        IBladedWeaponView View { get; }
        
        void Hit();
    }
}