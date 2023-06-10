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
        [SerializeField] private UnityButton _joinRoomButton;
        [SerializeField] private CreateRoomButton _createRoomButton;
        [SerializeField] private RoomsList _roomsList;
        [SerializeField] private NickNameField _nickNameField;
        
        private void Awake()
        {
            INetwork network = new Network();
            IScene gameScene = new SceneWithLoadingView(new AsyncScene(_game), _sceneLoadingView);

            _roomsList.Init(network);
            _joinRoomButton.Init(new JoinRandomRoomButton(network));
            _createRoomButton.Init(gameScene);
            _nickNameField.Init(network.Player);
            
            if (!network.IsConnected)
                network.Connect();
        }
    }
}