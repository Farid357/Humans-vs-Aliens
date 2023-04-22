using HumansVsAliens.LoadSystem;
using HumansVsAliens.Networking;
using Photon.Pun;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        private IRoom _room;
        
        private void Awake()
        {
            INetwork network = new Network();
            network.Connect();
        }
        
        public void JoinRoom()
        {
            Debug.Log("try Joined");
            PhotonNetwork.JoinRandomRoom();
        }

        public void CreateRoom()
        {
            _room = new Room(_game);
            _room.Create();
        }
    }
}