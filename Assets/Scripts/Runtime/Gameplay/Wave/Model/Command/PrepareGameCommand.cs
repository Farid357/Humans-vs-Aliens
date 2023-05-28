using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public class PrepareGameCommand : ICommand
    {
        private readonly IWavesView _wavesView;
        private readonly IWave _wave;

        public PrepareGameCommand(IWave wave, IWavesView wavesView)
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