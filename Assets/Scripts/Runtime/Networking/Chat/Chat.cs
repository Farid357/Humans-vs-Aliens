using ExitGames.Client.Photon;
using HumansVsAliens.GameLoop;
using Photon.Chat;
using Photon.Pun;

namespace HumansVsAliens.Networking
{
    public class Chat : IChat, IGameLoopObject, IChatClientListener
    {
        private readonly ChatClient _chatClient;
        private const string ChannelName = "GeneralChat";

        public Chat()
        {
            _chatClient = new ChatClient(this);
            string appIdChat = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat;
            _chatClient.Connect(appIdChat, PhotonNetwork.AppVersion, new AuthenticationValues());
        }

        public void Update(float deltaTime)
        {
            _chatClient.Service();
        }

        public void SendMessage(string text)
        {
            _chatClient.PublishMessage(ChannelName, text);
        }

        public void SendPrivateMessageTo(string text, IReadOnlyNetworkPlayer player)
        {
            _chatClient.SendPrivateMessage(player.Name, text);
        }

        public void OnConnected()
        {
            _chatClient.Subscribe(ChannelName);
        }

        public void OnDisconnected()
        {
            _chatClient.Unsubscribe(new[] { ChannelName });
        }

        public void DebugReturn(DebugLevel level, string message)
        {
        }

        public void OnChatStateChange(ChatState state)
        {
        }

        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
        }

        public void OnPrivateMessage(string sender, object message, string channelName)
        {
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
        }

        public void OnUnsubscribed(string[] channels)
        {
        }

        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
        }

        public void OnUserSubscribed(string channel, string user)
        {
        }

        public void OnUserUnsubscribed(string channel, string user)
        {
        }
    }
}