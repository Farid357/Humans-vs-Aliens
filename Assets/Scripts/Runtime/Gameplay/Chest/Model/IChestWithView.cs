namespace HumansVsAliens.Gameplay
{
    public interface IChestWithView : IChest
    {
        bool IsActive { get; }

        void Destroy();
    }
}