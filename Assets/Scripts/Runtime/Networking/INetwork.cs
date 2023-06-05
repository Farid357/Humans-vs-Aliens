namespace HumansVsAliens.Networking
{
    public interface INetwork : IReadOnlyNetwork
    {
        void Connect();
    }
}