using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class HealGoodFactory : MonoBehaviour, IGoodFactory
    {
        [SerializeField] private GoodWithViewFactory _viewFactory;
        [SerializeField] private HealGoodData _data;

        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public (IGood, IGoodData) Create()
        {
            IGood good = new HealGood(_health, _data.Heal);
            IGood goodWithView = _viewFactory.CreateFor(good);
            return (goodWithView, _data);
        }
    }
}