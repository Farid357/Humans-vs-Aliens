using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Good : IGood
    {
        private readonly IGoodView _view;

        public Good(IGoodData data, IGoodView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool IsBought { get; private set; }

        public IGoodData Data { get; }

        public void Buy()
        {
            if (IsBought)
                throw new InvalidOperationException($"Good is already bought!");

            IsBought = true;
            _view.Buy();
        }
    }
}