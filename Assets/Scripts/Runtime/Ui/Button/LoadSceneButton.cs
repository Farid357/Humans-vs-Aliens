using System;
using HumansVsAliens.SceneManagement;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class LoadSceneButton : MonoBehaviour
    {
        private IScene _scene;
        private UnityEngine.UI.Button _button;

        public void Init(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(Press);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Press);
        }

        private void Press()
        {
            _scene.Load();
        }
    }
}