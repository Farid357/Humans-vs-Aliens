namespace HumansVsAliens.Networking
{
    public interface IServer<TModel>
    {
        bool CanSendCommands { get; }
        
        void SendCommand(IServerCommand<TModel> command, TModel model);

        void SendCommandToClients(IServerCommand<TModel> command, TModel model);
    }
}