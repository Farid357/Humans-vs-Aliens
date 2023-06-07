using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Cheats
{
    [TestFixture]
    public class CheatsConsoleTest
    {
        [Test]
        public void ActivatesCorrectly()
        {
            ICheatsConsole cheatsConsole = new CheatsConsole();
            var cheat = new FakeCheat();
            const string cheatName = nameof(FakeCheat);
          
            cheatsConsole.AddCheat(cheat, cheatName);
            
            Assert.That(cheatsConsole.ContainsCheat(cheatName));
            
            cheatsConsole.ActivateCheat(cheatName);
            Assert.That(cheat.IsActivated);
        }
    }
}