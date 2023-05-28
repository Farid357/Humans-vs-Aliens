namespace HumansVsAliens.Networking
{
    public interface IServer
    {
        bool IsConnected { get; }
        
        void SendCommand(IServerCommand command, ServerCommandReceivers receivers);
    }
}



