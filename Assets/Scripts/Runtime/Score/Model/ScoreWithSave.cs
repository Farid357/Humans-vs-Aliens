using System;
using SaveSystem;

namespace HumansVsAliens.Model
{
    public sealed class ScoreWithSave : IScore
    {
        private readonly IScore _score;
        private readonly ISaveStorage<int> _scoreStorage;

        public ScoreWithSave(IScore score, ISaveStorage<int> scoreStorage)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _scoreStorage = scoreStorage ?? throw new ArgumentNullException(nameof(scoreStorage));
        }

        public int Count => _score.Count;

        public void Add(int count)
        {
            _score.Add(count);
            _scoreStorage.Save(_score.Count);
        }
    }
}