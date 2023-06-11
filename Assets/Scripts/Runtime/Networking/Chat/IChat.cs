namespace HumansVsAliens.Networking
{
    public interface IChat
    {
        void SendMessage(string text);

        void SendPrivateMessageTo(string text, IReadOnlyNetworkPlayer player);
    }
}