using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyRewardFactory : MonoBehaviour, IRewardFactory
    {
        [SerializeField, Min(5)] private int _money = 5;
        [SerializeField, Min(5)] private int _scoreCount = 10;

        private IWallet _wallet;
        private IScore _score;

        public void Init(IWallet wallet, IScore score)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public IReward Create()
        {
            IReward reward = new Rewards(new List<IReward>()
            {
                new MoneyReward(_wallet, _money),
                new ScoreReward(_score, _scoreCount)
            });

            return reward;
        }
    }
}