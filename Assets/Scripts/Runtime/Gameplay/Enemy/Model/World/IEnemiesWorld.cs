namespace HumansVsAliens.Gameplay
{
    public interface IEnemiesWorld : IReadOnlyEnemiesWorld
    {
        void Add(IEnemy enemy, EnemyType type);
    }
}