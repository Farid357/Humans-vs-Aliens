using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class BonusLoop : IBonusLoop
    {
        private readonly IReadOnlyList<IBonusFactory> _bonusFactories;

        public BonusLoop(IReadOnlyList<IBonusFactory> bonusFactories)
        {
            _bonusFactories = bonusFactories ?? throw new ArgumentNullException(nameof(bonusFactories));
        }

        public async void Start()
        {
            while (true)
            {
                await Task.Delay(15000);
                IBonusFactory bonusFactory = _bonusFactories.GetRandom();
                bonusFactory.Create();
            }
        }
    }
}