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
            var view = new DummyChestView();
            IChest chest = new Chest(view, new FakeReward());
            chest.Open();
            Assert.That(chest.IsOpen);
            Assert.That(view.IsOpen);
        }
    }
}