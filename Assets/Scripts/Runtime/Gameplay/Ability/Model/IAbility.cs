namespace HumansVsAliens.Gameplay
{
    public interface IAbility
    {
        bool IsActive { get; }

        void Activate();

        void Deactivate();
    }
}