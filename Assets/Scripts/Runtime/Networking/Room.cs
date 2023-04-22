using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace HumansVsAliens.Networking
{
    public class Room : IRoom, IMatchmakingCallbacks
    {
        public Room(byte maxPlayers = 4)
        {
            Photon.Pun.PhotonNetwork.AddCallbackTarget(this);
            
            RoomOptions roomOptions = new RoomOptions
            {
                IsOpen = true,
                MaxPlayers = maxPlayers
            };

            Photon.Pun.PhotonNetwork.CreateRoom("Arena", roomOptions);
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            
        }

        public void OnCreatedRoom()
        {
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinedRoom()
        {
            SceneManager.LoadScene(1);
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
        }
    }
}