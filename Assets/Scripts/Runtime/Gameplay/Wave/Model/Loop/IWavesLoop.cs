using HumansVsAliens.GameLoop;

namespace HumansVsAliens.Gameplay
{
    public interface IWavesLoop : IWave, IGameLoopObject, IReadOnlyWavesLoop
    {
        void SetStatus(WavesLoopStatus status);
    }
}