using HumansVsAliens.View;

namespace HumansVsAliens.Tests
{
    public class DummyChestView : IChestView
    {
        public bool IsOpen { get; private set; }

        public void Open()
        {
            IsOpen = true;
        }
    }
}