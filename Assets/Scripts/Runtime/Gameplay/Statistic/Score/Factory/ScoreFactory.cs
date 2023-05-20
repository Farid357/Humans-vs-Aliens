using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ScoreFactory : MonoBehaviour, IScoreFactory
    {
        [SerializeField] private ScoreView _scoreView;

        public IScore Create()
        {
            IScore score = new ScoreSynchronization(new Score(_scoreView));
            return score;
        }
    }
}