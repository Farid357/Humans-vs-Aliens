using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(Button))]
    public class CreateRoomButton : MonoBehaviour
    {
        [SerializeField] private PlayersToggle _toggle;
        [SerializeField] private RoomNameField _nameField;
        [SerializeField] private TMP_Text _errorText;

        private CancellationToken _cancellationToken;
        private Button _button;

        private void Awake()
        {
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Press);
        }

        private async void Press()
        {
            if (!_nameField.IsValid)
            {
                await SetErrorText("Can't create room because it's name is invalid!!");
                return;
            }

            var roomOptions = new RoomOptions { MaxPlayers = _toggle.SelectedPlayersCount };
            Debug.Log($"Created Room (players: {roomOptions.MaxPlayers}");
            PhotonNetwork.CreateRoom(_nameField.Text, roomOptions, TypedLobby.Default);
        }

        private async Task SetErrorText(string text)
        {
            _errorText.text = text;
            await UniTask.Delay(TimeSpan.FromSeconds(0.75f), cancellationToken: _cancellationToken);
            _errorText.text = string.Empty;
        }

        private void OnDestroy() => _button.onClick.RemoveListener(Press);
        
    }
}