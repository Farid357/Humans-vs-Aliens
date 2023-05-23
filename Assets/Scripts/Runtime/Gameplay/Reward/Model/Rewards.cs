using System;
using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public class Rewards : IReward
    {
        private readonly IReadOnlyList<IReward> _all;

        public Rewards(IReadOnlyList<IReward> all)
        {
            if (all.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(all));

            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public void Apply()
        {
            foreach (IReward reward in _all)
            {
                reward.Apply();
            }
        }
    }
}