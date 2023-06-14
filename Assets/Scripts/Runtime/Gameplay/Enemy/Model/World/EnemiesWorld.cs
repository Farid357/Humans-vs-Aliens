using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class EnemiesWorld : IEnemiesWorld
    {
        private readonly Dictionary<IEnemy, EnemyType> _enemies;

        public EnemiesWorld()
        {
            _enemies = new Dictionary<IEnemy, EnemyType>();
        }

        public IReadOnlyList<IEnemy> Enemies => _enemies.Keys.ToList();

        public bool EverybodyDied => _enemies.Keys.All(enemy => enemy.Health.IsDied());
       
        public EnemyType GetType(IEnemy enemy)
        {
            return _enemies[enemy];
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