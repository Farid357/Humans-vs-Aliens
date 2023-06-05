using HumansVsAliens.Networking;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ScoreFactory : MonoBehaviour, IScoreFactory
    {
        [SerializeField] private ScoreView _scoreView;

        public IScore Create(IReadOnlyNetwork network)
        {
            IScore score = new NetworkScore(new Score(_scoreView), network);
            return score;
        }
    }
}