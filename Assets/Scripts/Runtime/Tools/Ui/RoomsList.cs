using System;
using System.Collections.Generic;
using HumansVsAliens.Networking;
using UnityEngine;

namespace HumansVsAliens.UI
{
    public sealed class RoomsList : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private RoomScrollItem _roomScrollItem;

        private readonly List<RoomScrollItem> _items = new();
        private IReadOnlyNetwork _network;

        public void Init(IReadOnlyNetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }
        
        private void OnEnable()
        {
            _items.ForEach(item => Destroy(item.gameObject));
            _items.Clear();
            
            foreach (IRoom room in _network.Rooms)
            {
                RoomScrollItem item = Instantiate(_roomScrollItem, _content);
                _items.Add(item);
                item.Visualize(room);
            }
        }
    }
}