using System;
using System.Threading.Tasks;
using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Abilities
{
    [TestFixture]
    public class TemporaryAbilityTest
    {
        [Test]
        public async void DeactivatesAndActivatesCorrectly()
        {
            IAbility ability = new TemporaryAbility(new Ability(new DummyAbilityView()), 0.2f);
            ability.Activate();
            Assert.That(ability.IsActive);
            await Task.Delay(TimeSpan.FromSeconds(0.2f));
            Assert.False(ability.IsActive);
        }
    }
}