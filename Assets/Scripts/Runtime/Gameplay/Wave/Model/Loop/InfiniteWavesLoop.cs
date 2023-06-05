using System;

namespace HumansVsAliens.Gameplay
{
    public sealed class InfiniteWavesLoop : IWavesLoop
    {
        private readonly IWavesQueue _wavesQueue;
        private readonly IWavesCounter _wavesCounter;
        private readonly ITimerBetweenWaves _timer;

        private IWave _wave;
        private bool _wasStarted;

        public InfiniteWavesLoop(IWavesQueue wavesQueue, IWavesCounter wavesCounter, ITimerBetweenWaves timer)
        {
            _wavesQueue = wavesQueue ?? throw new ArgumentNullException(nameof(wavesQueue));
            _wavesCounter = wavesCounter ?? throw new ArgumentNullException(nameof(wavesCounter));
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
        }

        public bool IsEnded => false;

        public WavesLoopStatus Status { get; private set; } = WavesLoopStatus.WaitFirstWave;

        public void Start()
        {
            _wasStarted = true;
            StartNextWave();
        }

        public void Update(float deltaTime)
        {
            if (!_wasStarted)
                return;

            if (_wave.IsEnded && !_timer.IsStarted)
            {
                _timer.Start();
                Status = WavesLoopStatus.WaitNextWave;
            }

            if (_timer.IsEnded && _wave.IsEnded)
                StartNextWave();
        }

        private void StartNextWave()
        {
            _wave = _wavesQueue.GetWave();
            _timer.Stop();
            _wave.Start();
            _wavesCounter.Increase();
            Status = WavesLoopStatus.WaveIsGoing;
        }
    }
}