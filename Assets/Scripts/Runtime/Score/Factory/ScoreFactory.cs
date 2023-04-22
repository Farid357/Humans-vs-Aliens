using HumansVsAliens.Model;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public class ScoreFactory : MonoBehaviour, IScoreFactory
    {
        [SerializeField] private ScoreView _scoreView;

        public IScore Create()
        {
            ISaveStorage<int> scoreStorage = new BinaryStorage<int>(new Path(nameof(IScore)));
            IScore score = new Score(_scoreView);
            score.Add(scoreStorage.LoadOrDefault());
            return new ScoreWithSave(score, scoreStorage);
        }
    }
}