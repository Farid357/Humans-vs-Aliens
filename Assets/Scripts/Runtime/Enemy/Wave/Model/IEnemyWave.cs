namespace HumansVsAliens.Model
{
    public interface IEnemyWave
    {
        bool IsEnded { get; }
        
        void Restart();
    }
}