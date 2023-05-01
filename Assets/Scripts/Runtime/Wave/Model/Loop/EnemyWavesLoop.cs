using System;

namespace HumansVsAliens.Model
{
    public sealed class EnemyWavesLoop : IEnemyWavesLoop
    {
        private readonly IEnemyWavesQueue _wavesQueue;
        
        private IEnemyWave _enemyWave;
        private bool _isStarted;
        
        public EnemyWavesLoop(IEnemyWavesQueue wavesQueue)
        {
            _wavesQueue = wavesQueue ?? throw new ArgumentNullException(nameof(wavesQueue));
        }

        public bool IsEnded => false;

        public void Start()
        {
            if (_isStarted)
                throw new InvalidOperationException($"Waves loop is already started!");
            
            _enemyWave = _wavesQueue.GetWave();
            _isStarted = true;
            _enemyWave.Start();
        }

        public void Update(float deltaTime)
        {
            if(!_isStarted)
                return;
            
            if (_enemyWave.IsEnded)
                StartNextWave();
        }

        private void StartNextWave()
        {
            _enemyWave = _wavesQueue.GetWave();
            _enemyWave.Start();
        }
    }
}