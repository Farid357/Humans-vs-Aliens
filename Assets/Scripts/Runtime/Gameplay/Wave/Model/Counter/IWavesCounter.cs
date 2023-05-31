namespace HumansVsAliens.Gameplay
{
    public interface IWavesCounter : IReadOnlyWavesCounter
    {
        void Increase();
    }
}