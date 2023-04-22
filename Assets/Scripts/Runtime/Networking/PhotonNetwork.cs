using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    public class PhotonNetwork : INetwork, IConnectionCallbacks, ILobbyCallbacks
    {
        public void Connect()
        {
            Photon.Pun.PhotonNetwork.AddCallbackTarget(this);
            Photon.Pun.PhotonNetwork.ConnectUsingSettings();
        }

        public void OnConnected()
        {
            Debug.Log("Connected!");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log("Connected to master!");
            Photon.Pun.PhotonNetwork.JoinLobby();
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected {cause}!");
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnJoinedLobby()
        {

        }

        public void OnLeftLobby()
        {
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
        }
    }
}