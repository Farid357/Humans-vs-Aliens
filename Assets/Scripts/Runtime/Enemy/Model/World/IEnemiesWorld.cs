namespace HumansVsAliens.Model
{
    public interface IEnemiesWorld : IReadOnlyEnemiesWorld
    {
        void Add(IEnemy enemy, EnemyType type);
    }
}