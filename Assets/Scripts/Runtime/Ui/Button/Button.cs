using UnityEngine;

namespace HumansVsAliens
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        
        public void Init()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(Press);
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(Press);
        }

        protected abstract void Press();
    }
}