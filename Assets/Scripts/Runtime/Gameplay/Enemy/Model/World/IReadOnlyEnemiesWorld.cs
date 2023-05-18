using HumansVsAliens.GameLoop;
using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyEnemiesWorld
    {
        IReadOnlyDictionary<IEnemy, EnemyType> Enemies { get; }
        
        bool EverybodyDied { get; }
    }
}