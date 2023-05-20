using System;
using System.Collections.Generic;
using HumansVsAliens.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class Room : IRoom, IMatchmakingCallbacks, IDisposable
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

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
    }
}