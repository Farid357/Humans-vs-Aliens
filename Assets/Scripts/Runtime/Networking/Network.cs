using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Network : INetwork, IConnectionCallbacks, ILobbyCallbacks, IDisposable
    {
        private readonly List<IRoom> _rooms = new();
        
        public Network()
        {
            Player = new NetworkPlayerWithNameSave();
            PhotonNetwork.AddCallbackTarget(this);
        }

        public bool IsConnected => PhotonNetwork.IsConnected;
     
        public bool IsMasterClient => PhotonNetwork.IsMasterClient;
     
        public INetworkPlayer Player { get; }

        public IReadOnlyList<IRoom> Rooms => _rooms;

        public IReadOnlyList<IReadOnlyNetworkPlayer> AllPlayers =>
            PhotonNetwork.PlayerList.Select(player => new NetworkPlayer(player)).ToList();

        public IReadOnlyList<IReadOnlyNetworkPlayer> InRoomPlayers => PhotonNetwork.CurrentRoom.Players
            .Select(player => new NetworkPlayer(player.Value)).ToList();

        public void Connect()
        {
            if (IsConnected)
                throw new InvalidOperationException($"Network is already connected!");

            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void OnConnected()
        {
        }

        public void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _rooms.Clear();

            foreach (RoomInfo roomInfo in roomList)
            {
                _rooms.Add(new Room(roomInfo.PlayerCount, roomInfo.MaxPlayers, roomInfo.Name));
            }
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
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
    }
}