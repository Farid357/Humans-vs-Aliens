using System.Collections.Generic;

namespace HumansVsAliens.Model
{
    public interface IReadOnlyEnemiesWorld
    {
        IReadOnlyDictionary<IEnemy, EnemyType> Enemies { get; }
        
        bool EverybodyDied { get; }
    }
}