using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public interface IChest
    {
        bool IsOpen { get; }

        IOnlyDestroyChestView View { get; }
        
        void Open();
    }
}