using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Server : IServer, IOnEventCallback, IDisposable
    {
        private readonly Dictionary<int, IServerCommand> _commands = new();
      
        private const byte ServerCommandsCode = 1;
        private const byte ClientsCommandsCode = 2;

        public Server()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public bool CanSendCommands => PhotonNetwork.IsConnectedAndReady;

        public void SendCommand(IServerCommand command)
        {
            SendCommand(command, ServerCommandsCode, ReceiverGroup.MasterClient);
        }

        public void SendCommandToClients(IServerCommand command)
        {
            SendCommand(command, ClientsCommandsCode, ReceiverGroup.All);
        }

        private void SendCommand(IServerCommand command, byte code, ReceiverGroup receivers)
        {
            int hashCode = command.GetHashCode();
            
            if (CanSendCommands == false)
                throw new InvalidOperationException($"Connect to network!");

            if (_commands.ContainsKey(hashCode))
                throw new InvalidOperationException($"Server is sending same command!");

            var raiseEventOptions = new RaiseEventOptions { Receivers = receivers };
            _commands.Add(hashCode, command);
            PhotonNetwork.RaiseEvent(code, hashCode, raiseEventOptions, SendOptions.SendReliable);
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.CustomData is not int)
                return;

            var commandHashCode = (int)photonEvent.CustomData;
            IServerCommand command = _commands[commandHashCode];
            command.Execute();
            _commands.Remove(commandHashCode);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
    }
}