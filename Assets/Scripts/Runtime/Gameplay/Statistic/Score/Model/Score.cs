using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public sealed class Score : IScore
    {
        private readonly IScoreView _view;

        public Score(int count, IScoreView view)
        {
            Count = count.ThrowIfLessThanZeroException();
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Count { get; private set; }

        public void Add(int count)
        {
            Count += count.ThrowIfLessThanZeroException();
            _view.Visualize(Count);
        }
    }
}