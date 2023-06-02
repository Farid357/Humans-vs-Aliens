using HumansVsAliens.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.Gameplay
{
    public class GameConfiguration : MonoBehaviour
    {
        [SerializeField] private Toggle _cheatsToggle;
        [SerializeField] private Toggle _wavesInfiniteToggle;
        [SerializeField] private Toggle _autoHealToggle;
        [SerializeField] private TMP_InputField _wavesCountText;

        public GameConfigurationSave Save
        {
            get
            {
                GameConfigurationSave save;

                if (_wavesInfiniteToggle.isOn)
                {
                    save = new GameConfigurationSave(cheatsAreEnabled: _cheatsToggle.isOn, autoHealIsOn: _autoHealToggle.isOn);
                }

                else
                {
                    int wavesCount = _wavesCountText.text.ToInt();
                    save = new GameConfigurationSave(wavesCount: wavesCount, cheatsAreEnabled: _cheatsToggle.isOn, _autoHealToggle.isOn);
                }

                return save;
            }
        }
    }
}