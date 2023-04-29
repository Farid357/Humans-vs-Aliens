using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Server<TModel> : IServer<TModel>, IOnEventCallback, IDisposable
    {
        private readonly Dictionary<Type, TModel> _commands = new();
        private const byte ServerCommandsCode = 1;
        private const byte ClientsCommandsCode = 2;
        
        public Server()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public bool CanSendCommands => PhotonNetwork.IsConnectedAndReady;
        
        public void SendCommand(IServerCommand<TModel> command, TModel model)
        {
            SendCommand(command, model, ServerCommandsCode, ReceiverGroup.MasterClient);
        }

        public void SendCommandToClients(IServerCommand<TModel> command, TModel model)
        {
            SendCommand(command, model, ClientsCommandsCode, ReceiverGroup.All);
        }

        private void SendCommand(IServerCommand<TModel> command, TModel model, byte code, ReceiverGroup receivers)
        {
            if (CanSendCommands == false)
                throw new InvalidOperationException();

            if (_commands.ContainsKey(command.GetType()))
                throw new InvalidOperationException($"Server is sending same command!");
            
            var raiseEventOptions = new RaiseEventOptions { Receivers = receivers};
            _commands.Add(command.GetType(), model);
            PhotonNetwork.RaiseEvent(code, command, raiseEventOptions, SendOptions.SendReliable);
        }

        public void OnEvent(EventData photonEvent)
        {
            var command = (IServerCommand<TModel>)photonEvent.CustomData;
            Type commandType = command.GetType();
            command.Execute(_commands[commandType]);
            _commands.Remove(commandType);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
    }
}