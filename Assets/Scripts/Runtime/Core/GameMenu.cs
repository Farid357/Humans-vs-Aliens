using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.UI;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens.Core
{
    public sealed class GameMenu : MonoBehaviour
    {
        [SerializeField] private UnityButton _menuButton;

        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();

        private void Awake()
        {
            INetwork network = new Network();
            IGameLoopObject chat = new Chat();
           
            _menuButton.Init(new LeaveRoomButton(network.CurrentRoom));
            _gameLoop.Add(chat);
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}