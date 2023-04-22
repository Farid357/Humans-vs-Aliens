using HumansVsAliens.View;

namespace HumansVsAliens.Model
{
    public interface IBladedWeapon
    {
        bool CanHit { get; }

        IBladedWeaponView View { get; }
        
        void Hit();
    }
}