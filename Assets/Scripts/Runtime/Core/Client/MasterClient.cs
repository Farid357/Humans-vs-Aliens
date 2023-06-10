using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Core
{
    public sealed class MasterClient : IMasterClient
    {
        private readonly IWavesView _wavesView;
        private readonly IWavesLoop _wavesLoop;

        public MasterClient(IWavesView wavesView, IWavesLoop wavesLoop)
        {
            _wavesView = wavesView ?? throw new ArgumentNullException(nameof(wavesView));
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
        }

        public async void StartGame()
        {
            await _wavesView.StartWave();
            _wavesLoop.Start();
        }
    }
}