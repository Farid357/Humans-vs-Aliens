namespace HumansVsAliens.Model
{
    public interface IWallet : IReadOnlyWallet
    {
        void Take(int money);
        
        void Put(int money);
    }
}