using HumansVsAliens.Model;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public class AlienFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Alien _alienPrefab;
        [SerializeField] private Character _character;
        [SerializeField] private int _health = 80;

        public IEnemy Create(Vector3 position)
        {
            Alien alien = Instantiate(_alienPrefab, position, Quaternion.identity);
            IHealth health = new Health(new CharacterHealthView(), _health);
            alien.Init(_character, health);
            return alien;
        }
    }
}