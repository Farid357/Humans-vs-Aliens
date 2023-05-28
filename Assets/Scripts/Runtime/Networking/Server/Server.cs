using Photon.Pun;
using System;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    //Trash server with photon
    [RequireComponent(typeof(PhotonView))]
    public class Server : MonoBehaviour, IServer
    {
        private IServerCommand _serverCommand;
        private PhotonView _photonView;

        public bool IsConnected => PhotonNetwork.IsConnectedAndReady;

        private void OnEnable()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void SendCommand(IServerCommand serverCommand, ServerCommandReceivers receivers)
        {
            if(!IsConnected)
                throw new InvalidOperationException($"Server is not connected! You can't send commands!");
            
            if(PhotonNetwork.IsMasterClient == false)
                return;
            
            _serverCommand = serverCommand ?? throw new ArgumentNullException(nameof(serverCommand));
            _photonView.RPC(nameof(SendCommandRpc), receivers.ToPhoton());
        }

        [PunRPC]
        private void SendCommandRpc()
        {
            _serverCommand.Execute();
        }
    }
}