namespace HumansVsAliens.Gameplay
{
    public interface IWeapon
    {
        bool CanShoot { get; }

        void Shoot();
    }
}