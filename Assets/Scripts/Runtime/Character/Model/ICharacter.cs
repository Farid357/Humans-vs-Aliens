namespace HumansVsAliens.Model
{
    public interface ICharacter : IReadOnlyCharacter
    {
        void Attack();

        void SwitchWeapon(IBladedWeapon weapon);
    }
}