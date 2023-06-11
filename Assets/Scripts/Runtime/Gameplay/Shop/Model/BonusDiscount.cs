using System;
using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class BonusDiscount : IGameLoopObject
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IShopWithDiscounts _shop;
        private readonly IList<int> _discountPercents;
        private readonly Random _random;

        private bool _receivedDiscount;

        public BonusDiscount(IReadOnlyWavesLoop wavesLoop, IShopWithDiscounts shop)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _random = new Random();

            _discountPercents = new List<int>()
            {
                25,
                50,
                75
            };
        }

        public void Update(float deltaTime)
        {
            if (_wavesLoop.Status == WavesLoopStatus.WaitNextWave && !_receivedDiscount)
            {
                double chance = _random.NextDouble();
                _receivedDiscount = true;

                if (chance <= 0.25f)
                    _shop.SetDiscount(_discountPercents.GetRandom());
            }

            if (_wavesLoop.Status == WavesLoopStatus.WaveIsGoing)
                _receivedDiscount = false;
        }
    }
}