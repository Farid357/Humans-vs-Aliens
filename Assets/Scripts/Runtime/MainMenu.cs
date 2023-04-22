using HumansVsAliens.Networking;
using UnityEngine;

namespace HumansVsAliens
{
    public sealed class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            INetwork network = new PhotonNetwork();
            network.Connect();
        }
        
        public void JoinRoom()
        {
            Photon.Pun.PhotonNetwork.JoinRandomRoom();
            foreach (var VARIABLE in Photon.Pun.PhotonNetwork.CurrentRoom.Players.Values)
            {
                Debug.Log(VARIABLE.NickName);
                
            }
        }

        public void CreateRoom()
        {
            IRoom room = new Room();
        }
    }
}