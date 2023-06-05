using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class WavesLoop : IWavesLoop
    {
        private readonly IReadOnlyWavesCounter _wavesCounter;
        private readonly IWavesLoop _wavesLoop;

        private readonly int _wavesCount;

        public WavesLoop(IWavesLoop wavesLoop, IReadOnlyWavesCounter wavesCounter, int wavesCount)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _wavesCounter = wavesCounter ?? throw new ArgumentNullException(nameof(wavesCounter));
            _wavesCount = wavesCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool IsEnded => _wavesCounter.PastWavesCount == _wavesCount && _wavesLoop.Status == WavesLoopStatus.WaitNextWave;

        public WavesLoopStatus Status => IsEnded ? WavesLoopStatus.Ended : _wavesLoop.Status;

        public void Start()
        {
            _wavesLoop.Start();
        }

        public void Update(float deltaTime)
        {
            if (IsEnded)
                return;

            _wavesLoop.Update(deltaTime);
        }
    }
}