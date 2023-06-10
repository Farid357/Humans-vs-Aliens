namespace HumansVsAliens.Networking
{
    public interface IChat
    {
        void SendMessage(string text);

        void SendPrivateMessage(string text, IReadOnlyNetworkPlayer player);
    }
}