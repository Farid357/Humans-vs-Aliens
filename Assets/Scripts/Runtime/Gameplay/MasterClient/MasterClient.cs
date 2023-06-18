using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public sealed class MasterClient : IMasterClient
    {
        private readonly IWavesView _wavesView;
        private readonly IWavesLoop _wavesLoop;
        private readonly IReadOnlyNetwork _network;

        public MasterClient(IWavesView wavesView, IWavesLoop wavesLoop, IReadOnlyNetwork network)
        {
            _wavesView = wavesView ?? throw new ArgumentNullException(nameof(wavesView));
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }

        public async void StartGame()
        {
            await _wavesView.StartWave();
            _wavesLoop.Start();
        }

        public void FinishGame()
        {
            _network.CurrentRoom.Leave();
        }
    }
}