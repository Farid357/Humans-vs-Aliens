using HumansVsAliens.Model;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public interface IEnemyFactory
    {
        IEnemy Create(Vector3 position);
    }
}