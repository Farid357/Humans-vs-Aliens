using System;
using System.Collections.Generic;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class BonusLoop : IBonusLoop
    {
        private readonly IReadOnlyList<IBonusFactory> _bonusFactories;
        private float _time;
        
        public BonusLoop(IReadOnlyList<IBonusFactory> bonusFactories)
        {
            _bonusFactories = bonusFactories ?? throw new ArgumentNullException(nameof(bonusFactories));
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= 5)
            {
                IBonusFactory bonusFactory = _bonusFactories.GetRandom();
                bonusFactory.Create();
                _time = 0;
            }
        }
    }
}