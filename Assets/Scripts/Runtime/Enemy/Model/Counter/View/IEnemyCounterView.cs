namespace HumansVsAliens.View
{
    public interface IEnemyCounterView
    {
        int ShowingCount { get; }

        void Show(int enemiesCount);
    }
}