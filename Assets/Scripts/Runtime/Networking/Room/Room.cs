using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using HumansVsAliens.Tools;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Room : IRoom, IInRoomCallbacks, IMatchmakingCallbacks, IDisposable
    {
        public Room(int currentPlayersCount, int maxPlayersCount, string name)
        {
            CurrentPlayersCount = currentPlayersCount.ThrowIfLessThanZeroException();
            MaxPlayersCount = maxPlayersCount.ThrowIfLessThanOrEqualsToZeroException();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhotonNetwork.AddCallbackTarget(this);
        }

        public bool IsPlayerIn => PhotonNetwork.CurrentRoom.Name == Name;

        public int CurrentPlayersCount { get; }

        public int MaxPlayersCount { get; }

        public string Name { get; }

        public void Join()
        {
            PhotonNetwork.JoinRoom(Name);
        }

        public void Leave()
        {
            if (!IsPlayerIn)
                throw new InvalidOperationException($"Player is not in room!");

            PhotonNetwork.LeaveRoom();
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
            if (!PhotonNetwork.LocalPlayer.IsMasterClient)
                return;

            foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
            {
                PhotonNetwork.CloseConnection(player);
            }
        }

        public void OnLeftRoom()
        {
            PhotonNetwork.LoadLevel(0);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
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
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }
    }
}