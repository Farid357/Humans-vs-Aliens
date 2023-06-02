using System;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class UnityButton : MonoBehaviour
    {
        private UnityEngine.UI.Button _unityButton;
        private IButton _button;

        public void Init(IButton button)
        {
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _unityButton = GetComponent<UnityEngine.UI.Button>();
            _unityButton.onClick.AddListener(_button.Press);
        }

        public void OnDestroy()
        {
            if (_button != null)
                _unityButton.onClick.RemoveListener(_button.Press);
        }
    }
}