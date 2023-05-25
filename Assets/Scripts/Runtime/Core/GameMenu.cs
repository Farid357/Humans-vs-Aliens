using System.Collections.Generic;
using HumansVsAliens.SceneManagement;
using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class GameMenu : MonoBehaviour
    {
        [SerializeField] private Scene _menuScene;
        [SerializeField] private UnityButton _menuButton;

        private void Awake()
        {
            _menuButton.Init(new Buttons(new List<IButton>
            {
                new LoadSceneButton(_menuScene),
                new LeaveRoomButton()
            }));
        }
    }
}