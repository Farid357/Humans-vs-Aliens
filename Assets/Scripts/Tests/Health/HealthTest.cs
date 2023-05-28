using HumansVsAliens.Gameplay;
using HumansVsAliens.Tools;
using NUnit.Framework;

namespace HumansVsAliens.Tests.HealthSystem
{
    [TestFixture]
    public class HealthTest
    {
        [Test]
        public void TakesDamageCorrectly()
        {
            IHealth health = new Health(100);
            health.TakeDamage(10);
            Assert.That(health.Value == 90);
        }

        [Test]
        public void KillsCorrectly()
        {
            IHealth health = new Health(100);
            health.Kill();
            Assert.That(health.Value == 0);
            Assert.That(health.IsDied());
        }

        [Test]
        public void HealsCorrectly()
        {
            IHealth health = new Health(100);
            health.Heal(10);
            Assert.That(health.Value == 110);
        }
    }
}