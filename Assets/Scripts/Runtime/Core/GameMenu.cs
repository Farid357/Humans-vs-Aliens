using HumansVsAliens.SceneManagement;
using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class GameMenu : MonoBehaviour
    {
        [SerializeField] private LoadSceneButton _menuButton;
        [SerializeField] private Scene _menuScene;
        
        private void Awake()
        {
            _menuButton.Init(_menuScene);
        }
    }
}