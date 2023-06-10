using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using HumansVsAliens.SceneManagement;
using HumansVsAliens.UI;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens.Core
{
    public sealed class GameMenu : MonoBehaviour
    {
        [SerializeField] private Scene _menuScene;
        [SerializeField] private UnityButton _menuButton;

        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();
        
        private void Awake()
        {
            _menuButton.Init(new Buttons(new List<IButton>
            {
                new LoadSceneButton(_menuScene),
                new LeaveRoomButton(new Network())
            }));

            var chat = new Chat();
            _gameLoop.Add(chat);
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}