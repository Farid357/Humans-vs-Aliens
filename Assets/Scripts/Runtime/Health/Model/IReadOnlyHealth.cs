namespace HumansVsAliens.Model
{
    public interface IReadOnlyHealth
    {
        bool IsAlive { get; }
        
        int Value { get; }
    }
}