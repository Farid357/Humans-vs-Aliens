namespace HumansVsAliens.Gameplay
{
    public interface ICharacterStatistics
    {
        IWallet Wallet { get; }

        IScore Score { get; }
    }
}