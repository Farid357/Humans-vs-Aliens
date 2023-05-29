using System;
using System.Threading;
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

        private bool _isPressed;
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
                await ShowNameFieldError();
                return;
            }

            if (_isPressed)
                return;
            
            var roomOptions = new RoomOptions { MaxPlayers = _toggle.SelectedPlayersCount };
            _isPressed = true;
            PhotonNetwork.CreateRoom(_nameField.Text, roomOptions, TypedLobby.Default);
        }

        private async UniTask ShowNameFieldError()
        {
            _errorText.text = "Can't create room because it's name is invalid!!";
            await UniTask.Delay(TimeSpan.FromSeconds(0.75f), cancellationToken: _cancellationToken);
            _errorText.text = string.Empty;
        }

        private void OnDestroy() => _button.onClick.RemoveListener(Press);
    }
}