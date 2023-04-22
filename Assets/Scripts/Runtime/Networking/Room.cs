using System;
using System.Collections.Generic;
using HumansVsAliens.LoadSystem;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    public class Room : IRoom, IMatchmakingCallbacks
    {
        private readonly IScene _scene;

        public Room(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            PhotonNetwork.AddCallbackTarget(this);
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
            Debug.Log("Joined");
            _scene.Load();
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

        public void Create()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                IsOpen = true,
                MaxPlayers = 4
            };

            PhotonNetwork.CreateRoom("Arena", roomOptions);
        }
    }
}