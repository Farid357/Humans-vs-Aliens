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
        }

        public bool IsEnded => false;

        public void Start()
        {
            _wave = _wavesQueue.GetWave();
            _wasStarted = true;
            _wave.Start();
        }

        public void Update(float deltaTime)
        {
            if (!_wasStarted)
                return;

            if (_wave.IsEnded && !_timer.IsStarted)
                _timer.Start();

            if (_timer.IsEnded && _wave.IsEnded)
                StartNextWave();
        }

        private void StartNextWave()
        {
            _wave = _wavesQueue.GetWave();
            _timer.Stop();
            _wave.Start();
        }
    }
}