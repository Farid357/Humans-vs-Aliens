using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens
{
    public sealed class RoomsList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Window _window;
        [SerializeField] private Transform _content;
        [SerializeField] private RoomScrollItem _roomScrollItem;

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (RoomInfo roomInfo in roomList)
            {
                RoomScrollItem item = Instantiate(_roomScrollItem, _content);
                IRoomData roomData = new RoomData(roomInfo.PlayerCount, roomInfo.MaxPlayers, roomInfo.Name);
                item.Visualize(roomData);
            }
        }
    }
}