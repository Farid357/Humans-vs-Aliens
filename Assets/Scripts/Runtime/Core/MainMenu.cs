using System.Collections.Generic;
using Network = HumansVsAliens.Networking.Network;
using HumansVsAliens.SceneManagement;
using HumansVsAliens.Networking;
using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        [SerializeField] private SceneLoadingView _sceneLoadingView;
        [SerializeField] private CreateRoomButton _createRoomButton;
        [SerializeField] private JoinRandomRoomButton _joinRoomButton;
        
        private List<Button> _buttons;

        private void Awake()
        {
            INetwork network = new Network();
            IScene gameScene = new SceneWithLoadingView(new AsyncScene(_game), _sceneLoadingView);
            IRoom gameRoom = new Room(gameScene);

            _buttons = new List<Button>
            {
                _createRoomButton,
                _joinRoomButton
            };

            _buttons.ForEach(button => button.Init());

            if (!network.IsConnected)
                network.Connect();
        }

        private void OnDestroy()
        {
            _buttons.ForEach(button => button.Dispose());
        }
    }
}