using TMPro;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputField : MonoBehaviour, IInputField
    {
        private TMP_InputField _inputField;
       
        public string Text => _inputField.text;

        public bool IsValid => true;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }
    }
}