namespace HumansVsAliens.Networking
{
    public interface INetwork
    {
        bool IsConnected { get; }
        
        void Connect();
    }
}