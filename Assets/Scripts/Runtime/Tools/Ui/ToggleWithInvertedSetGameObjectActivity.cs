using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.Tools
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleWithInvertedSetGameObjectActivity : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        private Toggle _toggle;
        
        private void OnEnable()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(SetActive);
        }

        private void SetActive(bool isOn)
        {
            _gameObject.SetActive(!isOn);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(SetActive);
        }
    }
}