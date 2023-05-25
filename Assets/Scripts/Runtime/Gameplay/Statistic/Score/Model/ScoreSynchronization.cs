using System;
using System.Collections.Generic;
using HumansVsAliens.Tools;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Gameplay
{
    public sealed class ScoreSynchronization : IScore, IMatchmakingCallbacks
    {
        private readonly IScore _score;

        public ScoreSynchronization(IScore score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            SetScore(0);
        }

        public int Count => _score.Count;

        public void Add(int count)
        {
            _score.Add(count);
            SetScore(_score.Count);
        }

        public void OnJoinedRoom()
        {
            SetScore(0);
        }

        private void SetScore(int count)
        {
            PhotonNetwork.LocalPlayer.SetScore(count);
        }

        #region PhotonTrash
        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnCreatedRoom()
        {
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
            SetScore(0);
        }

        #endregion PhotonTrash
    }
}