namespace HumansVsAliens.Networking
{
    public interface INetwork
    {
        bool IsMasterClient { get; }
        
        bool IsConnected { get; }
        
        void Connect();
    }
}