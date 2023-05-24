using System;
using SaveSystem;

namespace HumansVsAliens.Gameplay
{
    public class GoodWithSave : IGood
    {
        private readonly IGood _good;
        private readonly ISaveStorage<bool> _wasBoughtStorage;

        public GoodWithSave(IGood good, ISaveStorage<bool> wasBoughtStorage)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _wasBoughtStorage = wasBoughtStorage ?? throw new ArgumentNullException(nameof(wasBoughtStorage));

            if (_wasBoughtStorage.HasSave() && _wasBoughtStorage.Load() && !_good.IsBought)
                throw new InvalidOperationException($"In storage good is bought, buy it with method to work correctly!");
        }

        public IGoodData Data => _good.Data;

        public bool IsBought => _good.IsBought;

        public void Buy()
        {
            _good.Buy();
            _wasBoughtStorage.Save(true);
        }
    }
}