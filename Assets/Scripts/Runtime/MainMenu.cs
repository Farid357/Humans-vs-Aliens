using HumansVsAliens.LoadSystem;
using HumansVsAliens.Networking;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        [SerializeField] private SceneLoadingView _sceneLoadingView;
        
        private IRoom _room;

        private void Awake()
        {
            INetwork network = new Network();
            IScene gameScene = new SceneWithLoadingView(new AsyncScene(_game), _sceneLoadingView);
            _room = new Room(gameScene);
            network.Connect();
        }
        
        public void JoinRoom()
        {
            Debug.Log("try Joined");
            _room.JoinRandom();
        }

        public void CreateRoom()
        {
            _room.EnterInNew();
        }
    }
}