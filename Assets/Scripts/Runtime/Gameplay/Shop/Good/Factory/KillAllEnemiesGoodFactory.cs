using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class KillAllEnemiesGoodFactory : MonoBehaviour, IGoodFactory
    {
        [SerializeField] private GoodWithViewFactory _viewFactory;
        [SerializeField] private GoodData _data;

        private IReadOnlyEnemiesWorld _enemiesWorld;

        public void Init(IReadOnlyEnemiesWorld enemiesWorld)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
        }

        public (IGood, IGoodData) Create()
        {
            IGood good = new KillAllEnemiesGood(_enemiesWorld);
            IGood goodWithView = _viewFactory.CreateFor(good);
            return (goodWithView, _data);
        }
    }
}