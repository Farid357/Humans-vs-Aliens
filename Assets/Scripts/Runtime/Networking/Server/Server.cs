using Photon.Pun;
using System;
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

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void SendCommand(IServerCommand serverCommand)
        {
            if(!IsConnected)
                throw new InvalidOperationException($"Server is not connected! You can't send commands!");

            _serverCommand = serverCommand ?? throw new ArgumentNullException(nameof(serverCommand));
            _photonView.RPC(nameof(SendCommandRpc), RpcTarget.All);
        }

        [PunRPC]
        private void SendCommandRpc()
        {
            _serverCommand.Execute();
        }
    }
}