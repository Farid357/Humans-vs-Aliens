using HumansVsAliens.Tools;
using HumansVsAliens.View;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ScoreFactory : MonoBehaviour, IScoreFactory
    {
        [SerializeField] private ScoreView _scoreView;

        public IScore Create()
        {
            ISaveStorage<int> scoreStorage = new BinaryStorage<int>(new Path(nameof(IScore) + "SaveCount"));
            int scoreCount = scoreStorage.LoadOrDefault();
            IScore score = new Score(scoreCount, _scoreView);
            _scoreView.Visualize(scoreCount);
            return new ScoreWithSave(score, scoreStorage);
        }
    }
}