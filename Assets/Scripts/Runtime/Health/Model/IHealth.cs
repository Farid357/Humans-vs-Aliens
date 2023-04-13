namespace HumansVsAliens.Model
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(int damage);
    }
}