namespace HumansVsAliens.View
{
    public interface IOnlyDestroyChestView
    {
        bool IsActive { get; }
        
        void Destroy();
    }
}