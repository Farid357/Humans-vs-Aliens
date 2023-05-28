using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests.HealthSystem
{
    [TestFixture]
    public class HealthWithHealClampTest
    {
        [Test]
        public void ClampsCorrectly()
        {
            const int startHealthValue = 100;
            const int customMaxHealthValue = 130;
            
            IHealth health = new HealthWithHealClamp(new Health(startHealthValue));
            health.Heal(10);
            Assert.That(health.Value == startHealthValue);
            
            IHealth healthWithCustomClamp = new HealthWithHealClamp(new Health(customMaxHealthValue));
            health.Heal(40);
            Assert.That(healthWithCustomClamp.Value == customMaxHealthValue);
        }
    }
}