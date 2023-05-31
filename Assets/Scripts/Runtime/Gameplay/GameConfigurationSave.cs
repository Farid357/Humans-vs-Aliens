using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    [Serializable]
    public struct GameConfigurationSave
    {
        private int _wavesCount;

        public GameConfigurationSave(int wavesCount, bool cheatsAreEnabled, bool autoHealIsOn)
        {
            _wavesCount = wavesCount.ThrowIfLessThanOrEqualsToZeroException();
            CheatsAreEnabled = cheatsAreEnabled;
            AutoHealIsOn = autoHealIsOn;
            WavesAreInfinite = false;
        }

        public GameConfigurationSave(bool cheatsAreEnabled, bool autoHealIsOn)
        {
            CheatsAreEnabled = cheatsAreEnabled;
            AutoHealIsOn = autoHealIsOn;
            _wavesCount = 0;
            WavesAreInfinite = true;
        }

        public bool WavesAreInfinite { get; }

        public bool CheatsAreEnabled { get; }
        
        public bool AutoHealIsOn { get; }

        public int WavesCount
        {
            get
            {
                if (WavesAreInfinite)
                    throw new InvalidOperationException($"Waves are infinite!");

                return _wavesCount;
            }
        }
    }
}