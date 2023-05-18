using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    //Trash server with photon
    [RequireComponent(typeof(PhotonView))]
    public class Server : MonoBehaviour, IServer
    {
        private IServerCommand _serverCommand;
        private PhotonView _photonView;

        public bool CanSendCommands => PhotonNetwork.IsConnectedAndReady;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void SendCommand(IServerCommand serverCommand)
        {
            _serverCommand = serverCommand ?? throw new System.ArgumentNullException(nameof(serverCommand));
            _photonView.RPC(nameof(SendCommandRpc), RpcTarget.All);
        }

        [PunRPC]
        private void SendCommandRpc()
        {
            _serverCommand.Execute();
        }
    }
}