namespace HumansVsAliens.Gameplay
{
    public interface IWave
    {
        bool IsEnded { get; }
        
        void Start();
    }
}