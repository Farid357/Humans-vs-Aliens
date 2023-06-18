using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Victory : IVictory
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IVictoryView _view;
        private readonly IMasterClient _masterClient;
        private readonly ILeaderboard _leaderboard;

        private float _time;
        private bool _gameIsFinished;
        
        public Victory(IReadOnlyWavesLoop wavesLoop, ILeaderboard leaderboard, IVictoryView view, IMasterClient masterClient)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _leaderboard = leaderboard ?? throw new ArgumentNullException(nameof(leaderboard));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _masterClient = masterClient ?? throw new ArgumentNullException(nameof(masterClient));
        }

        public bool IsActive { get; private set; }

        public void Update(float deltaTime)
        {
            if (IsActive && !_gameIsFinished)
            {
                _time += deltaTime;

                if (_time >= 5)
                {
                    _masterClient.FinishGame();
                    _gameIsFinished = true;
                }

                return;
            }

            TryActivate();
        }

        private void TryActivate()
        {
            if (_wavesLoop.Status == WavesLoopStatus.Ended)
            {
                IsActive = true;
                _leaderboard.Show();
                _view.ShowVictory();
            }
        }
    }
}