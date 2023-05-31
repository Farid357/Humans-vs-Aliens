using HumansVsAliens.Tools;
using SaveSystem;
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

        private ISaveStorage<GameConfigurationSave> _saveStorage;
        
        private void Awake()
        {
            _saveStorage = SaveStorages.GameConfiguration;
        }

        public void Save()
        {
            if (_wavesInfiniteToggle.isOn)
            {
                var save = new GameConfigurationSave(cheatsAreEnabled: _cheatsToggle.isOn, autoHealIsOn: _autoHealToggle.isOn);
                _saveStorage.Save(save);
            }
            
            else
            {
                int wavesCount = _wavesCountText.text.ToInt();
                var save = new GameConfigurationSave(wavesCount: wavesCount, cheatsAreEnabled: _cheatsToggle.isOn, _autoHealToggle.isOn);
                _saveStorage.Save(save);
            }
        }
    }
}