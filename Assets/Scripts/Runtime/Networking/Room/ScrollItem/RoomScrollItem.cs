using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens
{
    public class RoomScrollItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _roomName;
        [SerializeField] private UnityEngine.UI.Button _joinButton;
        
        public void Visualize(IRoomData roomData)
        {
            _playersText.text = $"{roomData.CurrentPlayersCount}/{roomData.MaxPlayersCount}";
            _roomName.text = roomData.Name;
            _joinButton.onClick.AddListener(Join);
        }

        private void Join()
        {
            PhotonNetwork.JoinRoom(_roomName.text);
        }
    }
}