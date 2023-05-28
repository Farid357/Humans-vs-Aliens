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
        
        private void Awake()
        {
            INetwork network = new Network();
          //  IScene gameScene = new SceneWithLoadingView(new AsyncScene(_game), _sceneLoadingView);
            IRoom room = new Room(_game);

            _joinRoomButton.Init(new JoinRandomRoomButton());
            
            if (!network.IsConnected)
                network.Connect();
        }
    }
}