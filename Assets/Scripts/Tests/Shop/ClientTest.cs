using HumansVsAliens.Gameplay;
using HumansVsAliens.Tests.Statistic;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Shop
{
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void BuysCorrectly()
        {
            const int goodPrice = 50;
            const int startMoney = 1000;

            IHealth health = new Health(100);
            IGood healGood = new HealGood(health, 10);

            IShop shop = new Gameplay.Shop();
            shop.Add(healGood, new DummyGoodData(goodPrice));

            IWallet wallet = new Wallet(new DummyWalletView(), startMoney);
            IClient client = new Client(new DummyClientView(), shop, wallet);
            client.SelectGood(healGood);
            Assert.That(client.HasGood);
            client.BuySelectedGood();
            Assert.That(wallet.Money == startMoney - goodPrice);
            Assert.That(health.Value == 110);
        }
    }
}