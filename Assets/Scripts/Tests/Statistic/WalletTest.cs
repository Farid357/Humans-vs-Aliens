using HumansVsAliens.Gameplay;
using NUnit.Framework;

namespace HumansVsAliens.Tests
{
    [TestFixture]
    public class WalletTest
    {
        [Test]
        public void PutsMoneyCorrect()
        {
            IWallet wallet = new Wallet(0, new DummyWalletView());
            wallet.Put(10);
            Assert.That(wallet.Money == 10);
        }

        [Test]
        public void TakesMoneyCorrect()
        {
            IWallet wallet = new Wallet(10, new DummyWalletView());
            wallet.Take(10);
            Assert.That(wallet.Money == 0);
            Assert.False(wallet.CanTake(10));
        }
    }
}
