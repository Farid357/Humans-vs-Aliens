using System;
using HumansVsAliens.Networking;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class NickNameField : MonoBehaviour
    {
        private INetworkPlayer _player;
        private TMP_InputField _inputField;

        public void Init(INetworkPlayer player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _inputField = GetComponent<TMP_InputField>();
            _inputField.text = _player.Name;
            _inputField.onValueChanged.AddListener(SetName);
        }

        private void SetName(string name)
        {
            _player.SwitchName(name);
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveListener(SetName);
        }
    }
}