using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Model
{
    public sealed class EnemiesWorld : IGameLoopObject, IEnemiesWorld
    {
        private readonly Dictionary<IEnemy, EnemyType> _enemies;

        public EnemiesWorld()
        {
            _enemies = new Dictionary<IEnemy, EnemyType>();
        }

        public IReadOnlyDictionary<IEnemy, EnemyType> Enemies => _enemies;

        public bool EverybodyDied => _enemies.Keys.All(enemy => !enemy.Health.IsAlive);

        public void Update(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.Key.Health.IsDied())
                {
                    _enemies.Remove(enemy.Key);
                    break;
                }
            }
        }

        public void Add(IEnemy enemy, EnemyType type)
        {
            if (enemy == null) 
                throw new ArgumentNullException(nameof(enemy));
            
            if (!Enum.IsDefined(typeof(EnemyType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(EnemyType));

            _enemies.Add(enemy, type);
        }
    }
}