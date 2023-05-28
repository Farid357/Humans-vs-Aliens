using System;
using HumansVsAliens.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HumansVsAliens.Gameplay
{
    public class HealBonusFactory : MonoBehaviour, IBonusFactory
    {
        [SerializeField] private BonusWithAutoPickUp _bonusPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField, Min(1)] private int _maxHeal = 10;
        [SerializeField, Min(1)] private int _minHeal = 5;
        
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }
        
        public IBonus Create()
        {
            Vector3 position = _spawnPoints.GetRandom().position;
            int heal = Random.Range(_minHeal, _maxHeal);
            BonusWithAutoPickUp bonus = Instantiate(_bonusPrefab, position, Quaternion.identity);
            bonus.Init(new HealBonus(new Bonus(bonus.View), _health, heal));
            return bonus;
        }
    }
}