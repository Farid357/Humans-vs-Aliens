using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tests
{
    public class FakeWavesLoop : IReadOnlyWavesLoop
    {
        public WavesLoopStatus Status { get; set; } = WavesLoopStatus.WaitFirstWave;
    }
}