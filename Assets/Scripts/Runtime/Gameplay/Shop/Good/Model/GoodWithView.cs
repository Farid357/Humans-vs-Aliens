using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public sealed class GoodWithView : IGood
    {
        private readonly IGoodView _view;
        private readonly IGood _good;

        public GoodWithView(IGood good, IGoodView view)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Use()
        {
            _good.Use();
            _view.Use();
        }
    }
}