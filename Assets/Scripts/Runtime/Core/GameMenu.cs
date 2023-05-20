using HumansVsAliens.SceneManagement;
using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class GameMenu : MonoBehaviour
    {
        [SerializeField] private Scene _menuScene;
        [SerializeField] private LoadSceneButton _menuButton;
        [SerializeField] private LeaveRoomButton _leaveRoomButton;

        private void Awake()
        {
            _menuButton.Init(_menuScene);
            _leaveRoomButton.Init();
        }
    }
}