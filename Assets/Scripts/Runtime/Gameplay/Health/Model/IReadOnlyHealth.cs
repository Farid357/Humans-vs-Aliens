namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyHealth
    {
        bool IsAlive { get; }
        
        int Value { get; }
    }
}