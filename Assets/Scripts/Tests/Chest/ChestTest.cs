using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests
{
    [TestFixture]
    public class ChestTest
    {
        [Test]
        public void OpensCorrectly()
        {
            IChest chest = new Chest(new FakeReward());
            chest.Open();
            Assert.That(chest.IsOpen);
        }
    }
}