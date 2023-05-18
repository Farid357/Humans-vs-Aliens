namespace HumansVsAliens.Gameplay
{
    public interface IEnemyWave
    {
        bool IsEnded { get; }
        
        void Restart();
    }
}