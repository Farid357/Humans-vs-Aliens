using System.Collections.Generic;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class GoodsFactory : MonoBehaviour
    {
        [SerializeField] private HealGoodFactory _healGoodFactory;
        [SerializeField] private KillAllEnemiesGoodFactory _killAllEnemiesGoodFactory;

        private readonly Dictionary<IGood, IGoodData> _goods = new();

        public void Init(IReadOnlyCharacter character, IReadOnlyEnemiesWorld enemiesWorld)
        {
            _healGoodFactory.Init(character.Health);
            _killAllEnemiesGoodFactory.Init(enemiesWorld);
        }

        public Dictionary<IGood, IGoodData> Create()
        {
            _goods.Clear();
            _goods.Add(_killAllEnemiesGoodFactory.Create());
            _goods.Add(_healGoodFactory.Create());
            return _goods;
        }
    }
}