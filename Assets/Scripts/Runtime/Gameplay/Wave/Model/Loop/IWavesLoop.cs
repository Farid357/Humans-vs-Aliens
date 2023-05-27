using HumansVsAliens.GameLoop;

namespace HumansVsAliens.Gameplay
{
    public interface IWavesLoop : IWave, IGameLoopObject, IReadOnlyWavesLoop
    {
    }

    public interface IReadOnlyWavesLoop
    {
        WavesLoopStatus Status { get; }
    }

    public enum WavesLoopStatus
    {
        WaitNextWave,
        WaveIsGoing
    }
}