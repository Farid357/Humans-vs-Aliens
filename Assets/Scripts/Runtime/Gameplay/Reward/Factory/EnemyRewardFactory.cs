using System;
using System.Collections.Generic;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class EnemyRewardFactory : IRewardFactory
    {
        private readonly ICharacterStatistics _statistics;
        private readonly int _money;
        private readonly int _scoreCount;

        public EnemyRewardFactory(ICharacterStatistics statistics, int money, int scoreCount)
        {
            _statistics = statistics ?? throw new ArgumentNullException(nameof(statistics));
            _money = money.ThrowIfLessThanOrEqualsToZeroException();
            _scoreCount = scoreCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IReward Create()
        {
            IReward reward = new Rewards(new List<IReward>()
            {
                new MoneyReward(_statistics.Wallet, _money),
                new ScoreReward(_statistics.Score, _scoreCount)
            });

            return reward;
        }
    }
}