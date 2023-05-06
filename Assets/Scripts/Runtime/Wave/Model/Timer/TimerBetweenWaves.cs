using HumansVsAliens.GameLoop;
using System;

namespace HumansVsAliens.Model
{
    public class TimerBetweenWaves : IGameLoopObject, ITimerBetweenWaves
    {
        private readonly ITimerBetweenWavesView _view;
        private float _time;

        public TimerBetweenWaves(ITimerBetweenWavesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsStarted { get; private set; }

        public bool IsEnded => _time <= 0f;

        public void Update(float deltaTime)
        {
            if (!IsStarted)
                return;

            _time -= deltaTime;
            _view.Visualize(_time);
        }

        public void Start()
        {
            IsStarted = true;
            Reset();
        }

        public void Stop()
        {
            _view.Clear();
            IsStarted = false;
            Reset();
        }

        private void Reset()
        {
            _time = 30f;
        }
    }
}