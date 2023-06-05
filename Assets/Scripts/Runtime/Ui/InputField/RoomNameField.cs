using TMPro;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class RoomNameField : MonoBehaviour, IInputField
    {
        [SerializeField] private TMP_Text _invalidNameText;
        
        private TMP_InputField _inputField;

        public string Text => _inputField.text;
        
        public bool IsValid => Text.Length >= 4;
        
        private void Start()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Update()
        {
            _invalidNameText.text = IsValid ? string.Empty : $"Too short name!";
        }
    }
}