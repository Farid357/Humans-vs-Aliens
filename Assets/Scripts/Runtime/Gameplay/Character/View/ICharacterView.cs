using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public interface ICharacterView
    {
        IHealthAnimations Animations { get; }

        void Attack();
        
        void SwitchWeapon();
    }
}