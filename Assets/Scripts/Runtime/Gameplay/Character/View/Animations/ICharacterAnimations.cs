namespace HumansVsAliens.View
{
    public interface ICharacterAnimations : IHealthAnimations, IAttackAnimation
    {
        void SwitchWeapon();
    }
}