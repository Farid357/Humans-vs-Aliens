using System;

namespace HumansVsAliens.Gameplay
{
    public class ChestLoop : IChestLoop
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IChestFactory _chestFactory;
        private bool _hasCreatedChest;

        public ChestLoop(IReadOnlyWavesLoop wavesLoop, IChestFactory chestFactory)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _chestFactory = chestFactory ?? throw new ArgumentNullException(nameof(chestFactory));
        }

        public void Update(float deltaTime)
        {
            if (_wavesLoop.Status == WavesLoopStatus.WaitNextWave && !_hasCreatedChest)
            {
                _chestFactory.Create();
                _hasCreatedChest = true;
            }

            if (_wavesLoop.Status == WavesLoopStatus.WaveIsGoing)
                _hasCreatedChest = false;
        }
    }
}