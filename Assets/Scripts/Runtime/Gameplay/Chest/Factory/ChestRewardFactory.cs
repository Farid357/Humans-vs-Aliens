using System;
using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public sealed class ChestRewardFactory : IRewardFactory
    {
        private readonly ICharacterStatistics _statistics;
        private readonly IAbility[] _abilities;

        private int _money;

        public ChestRewardFactory(ICharacterStatistics statistics)
        {
            _statistics = statistics ?? throw new ArgumentNullException(nameof(statistics));
        }

        public IReward Create()
        {
            // IAbility ability = _abilities.GetRandom();
            // return new AbilityReward(ability);

            _money += 50;
            return new Rewards(new List<IReward>
            {
                new MoneyReward(_statistics.Wallet, _money),
                new ScoreReward(_statistics.Score, 100),
            });
        }
    }
}