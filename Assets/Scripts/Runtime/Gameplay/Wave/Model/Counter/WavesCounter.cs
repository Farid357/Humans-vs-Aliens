using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class WavesCounter : IWavesCounter
    {
        private readonly IWavesCounterView _view;

        public WavesCounter(IWavesCounterView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int PastWavesCount { get; private set; }

        public void Increase()
        {
            PastWavesCount += 1;
            _view.Visualize(PastWavesCount);
        }
    }
}