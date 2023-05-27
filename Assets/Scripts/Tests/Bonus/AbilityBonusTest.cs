using HumansVsAliens.Gameplay;
using HumansVsAliens.Tests.Abilities;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Bonuses
{
    [TestFixture]
    public class AbilityBonusTest
    {
        [Test]
        public void ActivatesAbility()
        {
            IAbility ability = new Ability(new DummyAbilityView());
            IBonus bonus = new AbilityBonus(new Bonus(new DummyBonusView()), ability);
            bonus.PickUp();
            Assert.That(ability.IsActive);
        }
    }
}