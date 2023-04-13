namespace HumansVsAliens.View
{
    public interface IBladedWeaponActivityView
    {
        bool IsActive { get; }

        void Enable();

        void Disable();
    }
}