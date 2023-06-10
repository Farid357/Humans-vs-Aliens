namespace HumansVsAliens.Gameplay
{
    public interface IProjectileFactory
    {
        IProjectile Create(int damage);
    }
}