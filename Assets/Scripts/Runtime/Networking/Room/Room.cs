using System;
using HumansVsAliens.Tools;
using Photon.Pun;

namespace HumansVsAliens.Networking
{
    public class Room : IRoom
    {
        public Room(int currentPlayersCount, int maxPlayersCount, string name)
        {
            CurrentPlayersCount = currentPlayersCount.ThrowIfLessThanZeroException();
            MaxPlayersCount = maxPlayersCount.ThrowIfLessThanOrEqualsToZeroException();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public bool IsPlayerIn => PhotonNetwork.InRoom;
        
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
    }
}