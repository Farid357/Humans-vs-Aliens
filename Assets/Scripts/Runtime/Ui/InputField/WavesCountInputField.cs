using System;
using HumansVsAliens.Tools;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class WavesCountInputField : MonoBehaviour, IInputField
    {
        private TMP_InputField _inputField;

        public string Text => _inputField.text;

        public bool IsValid => !string.IsNullOrEmpty(Text) && Text.ToInt() > 0;

        public int Count => IsValid ? _inputField.text.ToInt() : throw new InvalidOperationException(nameof(IsValid));

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }
    }
}