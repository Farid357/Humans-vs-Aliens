using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class GoodWithView : MonoBehaviour, IGood
    {
        [SerializeField] private GoodView _view;
        
        private IGood _good;

        public void Init(IGood good)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
        }
        
        public void Buy()
        {
            _good.Buy();
            _view.Buy();
        }
    }
}