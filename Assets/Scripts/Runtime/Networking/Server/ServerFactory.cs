using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    public class ServerFactory : MonoBehaviour, IServerFactory
    {
        [SerializeField] private Server _server;
        
        public IServer Create()
        {
            IServer server = PhotonNetwork.Instantiate(_server.name, Vector3.one, Quaternion.identity).GetComponent<IServer>();
            return server;
        }
    }
}