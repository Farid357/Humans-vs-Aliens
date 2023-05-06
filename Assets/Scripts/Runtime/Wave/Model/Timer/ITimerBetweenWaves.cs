namespace HumansVsAliens.Model
{
    public interface ITimerBetweenWaves
    {
        bool IsEnded { get; }
        bool IsStarted { get; }

        void Start();

        void Stop();
    }
}