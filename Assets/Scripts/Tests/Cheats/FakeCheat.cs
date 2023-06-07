using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tests.Cheats
{
    public class FakeCheat : ICheat
    {
        public bool IsActivated { get; private set; }
        
        public void Activate()
        {
            IsActivated = true;
        }
    }
}