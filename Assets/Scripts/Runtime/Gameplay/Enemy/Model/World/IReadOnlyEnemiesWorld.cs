using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyEnemiesWorld
    {
        IReadOnlyList<IEnemy> Enemies { get; }
        
        bool EverybodyDied { get; }

        EnemyType GetType(IEnemy enemy);
    }
}