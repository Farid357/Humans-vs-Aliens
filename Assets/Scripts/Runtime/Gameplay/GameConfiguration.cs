using System;
using HumansVsAliens.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.Gameplay
{
    public class GameConfiguration : MonoBehaviour
    {
        [SerializeField] private Toggle _cheatsToggle;
        [SerializeField] private Toggle _wavesInfiniteToggle;
        [SerializeField] private Toggle _autoHealToggle;
        [SerializeField] private WavesCountInputField _wavesField;

        public GameConfigurationSave Save
        {
            get
            {
                if (CanGetSave == false)
                    throw new ArgumentOutOfRangeException(nameof(CanGetSave));
                
                if (_wavesInfiniteToggle.isOn)
                {
                    return new GameConfigurationSave(cheatsAreEnabled: _cheatsToggle.isOn, autoHealIsOn: _autoHealToggle.isOn);
                }

                else
                {
                    int wavesCount = _wavesField.Count;
                    return new GameConfigurationSave(wavesCount: wavesCount, cheatsAreEnabled: _cheatsToggle.isOn, _autoHealToggle.isOn);
                }
            }
        }

        public bool CanGetSave => _wavesInfiniteToggle.isOn || _wavesField.IsValid;
    }
}