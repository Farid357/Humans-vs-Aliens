using System;
using System.Threading.Tasks;

namespace HumansVsAliens.Gameplay
{
    public class TimerBetweenWaves : ITimerBetweenWaves
    {
        private readonly ITimerBetweenWavesView _view;
        private int _time;

        public TimerBetweenWaves(ITimerBetweenWavesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsStarted { get; private set; }

        public bool IsEnded => _time == 0;

        public async void Start()
        {
            IsStarted = true;
            Reset();

            while (!IsEnded)
            {
                await Task.Delay(1000);
                _time -= 1;
                _view.Visualize(_time);
            }
        }

        public void Stop()
        {
            _view.Clear();
            IsStarted = false;
            Reset();
        }

        private void Reset()
        {
            _time = 30;
        }
    }
}