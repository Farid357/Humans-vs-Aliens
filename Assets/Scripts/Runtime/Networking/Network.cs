using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Network : INetwork, IConnectionCallbacks, IDisposable
    {
        public Network()
        {
            Player = new NetworkPlayer(PhotonNetwork.LocalPlayer.NickName);
            PhotonNetwork.AddCallbackTarget(this);
        }

        public INetworkPlayer Player { get; }

        public bool IsConnected => PhotonNetwork.IsConnected;

        public bool IsMasterClient => PhotonNetwork.IsMasterClient;

        public IReadOnlyList<IReadOnlyNetworkPlayer> AllPlayers =>
            PhotonNetwork.PlayerList.Select(player => new NetworkPlayer(player.NickName)).ToList();

        public IReadOnlyList<IReadOnlyNetworkPlayer> InRoomPlayers => PhotonNetwork.CurrentRoom.Players
            .Select(player => new NetworkPlayer(player.Value.NickName)).ToList();

        public void Connect()
        {
            if (IsConnected)
                throw new InvalidOperationException($"Network is already connected!");

            PhotonNetwork.ConnectUsingSettings();
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
    }
}