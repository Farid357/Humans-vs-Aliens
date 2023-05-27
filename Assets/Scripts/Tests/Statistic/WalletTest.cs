using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests.Statistic
{
    [TestFixture]
    public class WalletTest
    {
        [Test]
        public void PutsMoneyCorrect()
        {
            IWallet wallet = new Wallet(new DummyWalletView(), 0);
            wallet.Put(10);
            Assert.That(wallet.Money == 10);
        }

        [Test]
        public void TakesMoneyCorrect()
        {
            IWallet wallet = new Wallet(new DummyWalletView(), 10);
            wallet.Take(10);
            Assert.That(wallet.Money == 0);
            Assert.False(wallet.CanTake(10));
        }
    }
}
