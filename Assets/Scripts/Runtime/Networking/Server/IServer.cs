namespace HumansVsAliens.Networking
{
    public interface IServer<out TModel>
    {
        bool CanSendCommands { get; }
        
        void SendCommand(IServerCommand<TModel> command);

        void SendCommandToClients(IServerCommand<TModel> command);
    }
}