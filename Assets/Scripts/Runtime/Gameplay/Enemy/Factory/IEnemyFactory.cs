using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IEnemyFactory
    {
        IEnemy Create(Vector3 position);
    }
}