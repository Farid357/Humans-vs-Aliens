namespace HumansVsAliens.Gameplay
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(int damage);

        void Heal(int heal);
    }
}