using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HumansVsAliens.Gameplay
{
    public class HealBonusFactory : MonoBehaviour, IBonusFactory
    {
        [SerializeField] private BonusView _bonusPrefab;
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
            IBonusView view = PhotonNetwork.Instantiate(_bonusPrefab.name, position, Quaternion.identity).GetComponent<BonusView>();
            return new HealBonus(new Bonus(view), _health, heal);
        }
    }
}