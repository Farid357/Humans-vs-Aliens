using TMPro;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class NickNameField : MonoBehaviour
    {
        private TMP_InputField _inputField;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _inputField.onValueChanged.AddListener(SetName);
        }

        private void SetName(string name)
        {
            PhotonNetwork.LocalPlayer.NickName = name;
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveListener(SetName);
        }
    }
}