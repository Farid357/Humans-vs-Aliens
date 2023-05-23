using System;
using HumansVsAliens.Tools;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HumansVsAliens.Gameplay
{
    public class HealBonusFactory : MonoBehaviour, IBonusFactory
    {
        [SerializeField] private PhysicsBonus _bonusPrefab;
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
            PhysicsBonus bonus = PhotonNetwork.Instantiate(_bonusPrefab.name, position, Quaternion.identity).GetComponent<PhysicsBonus>();
            bonus.Init(new HealBonus(new Bonus(bonus.View), _health, heal));
            return bonus;
        }
    }
}