using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    public class Network : INetwork, IConnectionCallbacks, ILobbyCallbacks
    {
        public void Connect()
        {
            PhotonNetwork.AddCallbackTarget(this);
            PhotonNetwork.ConnectUsingSettings();
        }

        public void OnConnected()
        {
            Debug.Log("Connected!");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log("Connected to master!");
            PhotonNetwork.JoinLobby();
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