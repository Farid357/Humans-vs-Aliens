using System;
using HumansVsAliens.Gameplay;
using HumansVsAliens.Tests.HealthSystem;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Bonuses
{
    [TestFixture]
    public class HealBonusTest
    {
        [Test]
        public void HealsCorrectly()
        {
            IHealth health = new Health(new DummyHealthView(), 50);
            IBonus bonus = new HealBonus(new Bonus(new DummyBonusView()), health, 10);
            bonus.PickUp();
            Assert.That(health.Value == 60);
            Assert.Throws<InvalidOperationException>(bonus.PickUp);
        }
    }
}