using HumansVsAliens.View;

namespace HumansVsAliens.Model
{
    public interface IBladedWeapon
    {
        bool CanHit { get; }

        IBladedWeaponActivityView View { get; }
        
        void Hit();
    }
}