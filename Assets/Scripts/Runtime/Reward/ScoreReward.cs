using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Model
{
    public class ScoreReward : IReward
    {
        private readonly IScore _score;
        private readonly int _addCount;

        public ScoreReward(IScore score, int addCount)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _addCount = addCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Apply()
        {
            _score.Add(_addCount);
        }
    }
}