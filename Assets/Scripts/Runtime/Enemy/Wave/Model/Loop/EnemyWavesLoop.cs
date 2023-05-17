using System;

namespace HumansVsAliens.Model
{
    public sealed class EnemyWavesLoop : IEnemyWavesLoop
    {
        private readonly IEnemyWavesQueue _wavesQueue;
        private readonly ITimerBetweenWaves _timer;

        private IEnemyWave _enemyWave;
        private bool _wasStarted;

        public EnemyWavesLoop(IEnemyWavesQueue wavesQueue, ITimerBetweenWaves timer)
        {
            _wavesQueue = wavesQueue ?? throw new ArgumentNullException(nameof(wavesQueue));
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
        }

        public bool IsEnded => false;

        public void Restart()
        {
            _enemyWave = _wavesQueue.GetWave();
            _wasStarted = true;
            _enemyWave.Restart();
        }

        public void Update(float deltaTime)
        {
            if (!_wasStarted)
                return;

            if (_enemyWave.IsEnded && !_timer.IsStarted)
                _timer.Start();

            if (_timer.IsEnded && _enemyWave.IsEnded)
                StartNextWave();
        }

        private void StartNextWave()
        {
            _enemyWave = _wavesQueue.GetWave();
            _timer.Stop();
            _enemyWave.Restart();
        }
    }
}