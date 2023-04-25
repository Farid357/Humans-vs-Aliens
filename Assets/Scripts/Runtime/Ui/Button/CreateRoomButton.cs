using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace HumansVsAliens
{
    public class CreateRoomButton : Button
    {
        [SerializeField] private PlayersToggle _toggle;
        [SerializeField] private RoomNameField _nameField;
        [SerializeField] private TMP_Text _errorText;
     
        private CancellationToken _cancellationToken;

        private void Start()
        {
            _cancellationToken = this.GetCancellationTokenOnDestroy();
        }

        protected override async void Press()
        {
            if (!_nameField.IsValid)
            {
                await SetErrorText("Can't create room because it's name is invalid!!");
                return;
            }

            var roomOptions = new RoomOptions
            {
                MaxPlayers = _toggle.SelectedPlayersCount
            };

            Debug.Log($"Created Room (players: {roomOptions.MaxPlayers}");
            bool createdRoom = PhotonNetwork.CreateRoom(_nameField.Text, roomOptions, TypedLobby.Default);

            if (!createdRoom)
                await SetErrorText("Can't create room!");
        }

        private async Task SetErrorText(string text)
        {
            _errorText.text = text;
            await UniTask.Delay(TimeSpan.FromSeconds(0.75f), cancellationToken: _cancellationToken);
            _errorText.text = string.Empty;
        }
    }
}