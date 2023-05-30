using HumansVsAliens.Tools;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;
using UnityEngine.Audio;

namespace HumansVsAliens.Audio
{
    public class Music : MonoBehaviour, IMusic
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _exposedParameterName = "Master";

        private ISaveStorage<float> _volumeStorage;
      
        public float Volume { get; private set; }

        private void Awake()
        {
            _volumeStorage = new BinaryStorage<float>(new Path(nameof(Music)));
            ChangeVolume(_volumeStorage.HasSave() ? _volumeStorage.Load() : 0.5f.ToAudioVolume());
        }

        public void ChangeVolume(float newVolume)
        {
            Volume = newVolume;
            _audioMixer.SetFloat(_exposedParameterName, Volume);
            _volumeStorage.Save(Volume);
        }
    }
}