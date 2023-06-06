using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestBonusFactory : MonoBehaviour, IBonusFactory
    {
        [SerializeField] private ChestFactory _chestFactory;
        [SerializeField] private BonusWithAutoPickUp _bonusPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        
        private IHealth _health;

        public IBonus Create()
        {
            Vector3 position = _spawnPoints.GetRandom().position;
            BonusWithAutoPickUp bonus = Instantiate(_bonusPrefab, position, Quaternion.identity);
            bonus.Init(new ChestBonus(new Bonus(bonus.View), _chestFactory));
            return bonus;
        }
    }
}