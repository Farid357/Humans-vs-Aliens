namespace HumansVsAliens.Model
{
    public interface ICharacter
    {
        bool IsAlive { get; }

        bool CanAttack { get; }
        
        ICharacterMovement Movement { get; }

        void Attack();

        void SwitchWeapon(IBladedWeapon weapon);
    }
}