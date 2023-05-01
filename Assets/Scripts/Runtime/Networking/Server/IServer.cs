namespace HumansVsAliens.Networking
{
    public interface IServer
    {
        bool CanSendCommands { get; }
        
        void SendCommand(IServerCommand command);

        void SendCommandToClients(IServerCommand command);
    }
}



