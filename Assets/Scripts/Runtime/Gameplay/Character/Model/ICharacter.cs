namespace HumansVsAliens.Gameplay
{
    public interface ICharacter : IReadOnlyCharacter
    {
        void Attack();

        void SwitchWeapon(IBladedWeapon weapon);
    }
}