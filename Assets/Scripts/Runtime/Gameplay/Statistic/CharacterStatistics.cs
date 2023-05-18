using System;

namespace HumansVsAliens.Gameplay
{
    public class CharacterStatistics : ICharacterStatistics
    {
        public CharacterStatistics(IWallet wallet, IScore score)
        {
            Wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            Score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public IWallet Wallet { get; }

        public IScore Score { get; }
    }
}