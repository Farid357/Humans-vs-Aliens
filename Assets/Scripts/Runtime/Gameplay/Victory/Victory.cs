using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Victory : IVictory, IGameLoopObject
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IVictoryView _view;
        private readonly ILeaderboard _leaderboard;

        public Victory(IReadOnlyWavesLoop wavesLoop, ILeaderboard leaderboard, IVictoryView view)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _leaderboard = leaderboard ?? throw new ArgumentNullException(nameof(leaderboard));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsActive { get; private set; }
        
        public void Update(float deltaTime)
        {
            if (IsActive)
                return;
            
            if (_wavesLoop.Status == WavesLoopStatus.Ended)
            {
                IsActive = true;
                _leaderboard.Show();
                _view.ShowVictory();
            }
        }
    }
}