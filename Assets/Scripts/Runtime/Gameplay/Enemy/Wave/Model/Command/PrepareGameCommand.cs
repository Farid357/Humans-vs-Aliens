using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public class PrepareGameCommand : IServerCommand
    {
        private readonly IEnemyWavesView _wavesView;
        private readonly IEnemyWave _wave;

        public PrepareGameCommand(IEnemyWave wave, IEnemyWavesView wavesView)
        {
            _wave = wave ?? throw new ArgumentNullException(nameof(wave));
            _wavesView = wavesView ?? throw new ArgumentNullException(nameof(wavesView));
        }

        public async void Execute()
        {
            await _wavesView.StartWave();
            _wave.Start();
        }
    }
}