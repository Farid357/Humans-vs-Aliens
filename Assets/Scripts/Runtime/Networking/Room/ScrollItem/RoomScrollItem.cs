using System;
using HumansVsAliens.Networking;
using TMPro;
using UnityEngine;

namespace HumansVsAliens
{
    public class RoomScrollItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _roomName;
        [SerializeField] private UnityEngine.UI.Button _joinButton;

        private IRoom _room;

        public void Visualize(IRoom room)
        {
            _room = room ?? throw new ArgumentNullException(nameof(room));

            _playersText.text = $"{_room.CurrentPlayersCount}/{_room.MaxPlayersCount}";
            _roomName.text = _room.Name;
            _joinButton.onClick.AddListener(Join);
        }

        private void Join()
        {
            _room.Join();
        }

        private void OnDestroy()
        {
            _joinButton.onClick.RemoveListener(Join);
        }
    }
}