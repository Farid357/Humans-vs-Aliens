using HumansVsAliens.Audio;
using HumansVsAliens.Tools;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.UI
{
    public class MusicVolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Music _music;

        private ISaveStorage<float> _valueStorage;
        
        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(ChangeVolume);
            _valueStorage = new BinaryStorage<float>(new Path(nameof(MusicVolumeSlider)));
            _slider.value = _valueStorage.HasSave() ? _valueStorage.Load() : 0.5f;
        }

        private void ChangeVolume(float value)
        {
            _music.ChangeVolume(value.ToAudioVolume());
            _valueStorage.Save(value);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(ChangeVolume);
        }
    }
}