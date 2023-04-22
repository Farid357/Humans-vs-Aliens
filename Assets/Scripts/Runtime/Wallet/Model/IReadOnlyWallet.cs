namespace HumansVsAliens.Model
{
    public interface IReadOnlyWallet
    {
        int Money { get; }
        
        bool CanTake(int money);
    }
}