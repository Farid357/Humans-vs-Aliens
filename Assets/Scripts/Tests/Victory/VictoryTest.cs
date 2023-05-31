using HumansVsAliens.Gameplay;
using HumansVsAliens.View;
using NUnit.Framework;

namespace HumansVsAliens.Tests
{
    [TestFixture]
    public class VictoryTest
    {
        [Test]
        public void ActivatesCorrectly()
        {
            IVictoryView view = new FakeVictoryView();
            var wavesLoop = new FakeWavesLoop();
            var victory = new Victory(wavesLoop, view);
            
            victory.Update(0.2f);
            Assert.False(victory.IsActive);
            
            wavesLoop.Status = WavesLoopStatus.Ended;
            victory.Update(0.3f);
            Assert.That(victory.IsActive);
        }
    }
}