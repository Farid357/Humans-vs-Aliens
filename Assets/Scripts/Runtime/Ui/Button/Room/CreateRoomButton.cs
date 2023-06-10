using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HumansVsAliens.Gameplay;
using HumansVsAliens.SceneManagement;
using HumansVsAliens.Tools;
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
        [SerializeField] private GameConfiguration _gameConfiguration;
        [SerializeField] private PlayersToggle _toggle;
        [SerializeField] private RoomNameField _nameField;
        [SerializeField] private TMP_Text _errorText;

        private IScene _gameScene;
        private bool _isPressed;
        private CancellationToken _cancellationToken;
        private Button _button;
        
        public void Init(IScene gameScene)
        {
            _gameScene = gameScene ?? throw new ArgumentNullException(nameof(gameScene));
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Press);
        }

        private void Press()
        {
            if (!_nameField.IsValid)
            {
                ShowError("Can't create room because it's name is invalid!!").Forget();
                return;
            }

            if (_isPressed)
                return;

            if (_gameConfiguration.CanGetSave == false)
            {
                ShowError("Can't create room because it's waves count is invalid!!").Forget();
                return;
            }

            var roomOptions = new RoomOptions { MaxPlayers = _toggle.SelectedPlayersCount, CustomRoomProperties = _gameConfiguration.Save.ToRoomProperties() };
            PhotonNetwork.CreateRoom(_nameField.Text, roomOptions, TypedLobby.Default);
            _gameScene.Load();
            _isPressed = true;
        }

        private async UniTaskVoid ShowError(string text)
        {
            _errorText.text = text;
            await UniTask.Delay(TimeSpan.FromSeconds(1.2f), cancellationToken: _cancellationToken);
            _errorText.text = string.Empty;
        }

        private void OnDestroy() => _button.onClick.RemoveListener(Press);
    }
}