namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyCharacter
    {
        bool IsAlive { get; }

        bool CanAttack { get; }
        
        IHealth Health { get; }
        
        ICharacterMovement Movement { get; }
        
        ICharacterCamera Camera { get; }
    }
}