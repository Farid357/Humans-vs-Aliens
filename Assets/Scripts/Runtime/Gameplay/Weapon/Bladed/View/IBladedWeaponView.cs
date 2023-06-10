namespace HumansVsAliens.View
{
    public interface IBladedWeaponView : IReadOnlyBladedWeaponView
    {
        void Enable();

        void Disable();
    }
}