using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class ChestsLoop : IChestsLoop
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IChestFactory _chestFactory;
        
        private IOnlyDestroyChestView _lastCreatedChest;
        private bool _createdChest;

        public ChestsLoop(IReadOnlyWavesLoop wavesLoop, IChestFactory chestFactory)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _chestFactory = chestFactory ?? throw new ArgumentNullException(nameof(chestFactory));
        }

        public void Update(float deltaTime)
        {
            if (_wavesLoop.Status == WavesLoopStatus.WaitNextWave && !_createdChest)
            {
                _lastCreatedChest = _chestFactory.Create().View;
                _createdChest = true;
            }

            if (_wavesLoop.Status == WavesLoopStatus.WaveIsGoing)
            {
                _createdChest = false;
                TryDestroyLastChest();
            }
        }

        private void TryDestroyLastChest()
        {
            if (_lastCreatedChest is not null && _lastCreatedChest.IsActive)
                _lastCreatedChest.Destroy();
        }
    }
}