using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens
{
    public sealed class RoomsList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private RoomScrollItem _roomScrollItem;

        private readonly List<RoomScrollItem> _items = new();
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _items.ForEach(item => Destroy(item.gameObject));
            _items.Clear();
            
            foreach (RoomInfo roomInfo in roomList)
            {
                RoomScrollItem item = Instantiate(_roomScrollItem, _content);
                IRoomData roomData = new RoomData(roomInfo.PlayerCount, roomInfo.MaxPlayers, roomInfo.Name);
                _items.Add(item);
                item.Visualize(roomData);
            }
        }
    }
}