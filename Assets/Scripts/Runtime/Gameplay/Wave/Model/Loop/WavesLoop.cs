using System;

namespace HumansVsAliens.Gameplay
{
    public sealed class WavesLoop : IWavesLoop
    {
        private readonly IWavesQueue _wavesQueue;
        private readonly ITimerBetweenWaves _timer;

        private IWave _wave;
        private bool _wasStarted;

        public WavesLoop(IWavesQueue wavesQueue, ITimerBetweenWaves timer)
        {
            _wavesQueue = wavesQueue ?? throw new ArgumentNullException(nameof(wavesQueue));
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
            Status = WavesLoopStatus.WaitNextWave;
        }

        public bool IsEnded => false;

        public WavesLoopStatus Status { get; private set; }

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
            Status = WavesLoopStatus.WaveIsGoing;
        }
    }
}