using HumansVsAliens.Tools;

namespace HumansVsAliens
{
    public sealed class GameConfigurationSave : IGameConfigurationSave
    {
        public GameConfigurationSave(int wavesCount, bool cheatsAreEnabled, bool autoHealIsOn)
        {
            WavesCount = wavesCount.ThrowIfLessThanOrEqualsToZeroException();
            CheatsAreEnabled = cheatsAreEnabled;
            AutoHealIsOn = autoHealIsOn;
            WavesAreInfinite = false;
        }

        public GameConfigurationSave(bool cheatsAreEnabled, bool autoHealIsOn)
        {
            CheatsAreEnabled = cheatsAreEnabled;
            AutoHealIsOn = autoHealIsOn;
            WavesCount = 0;
            WavesAreInfinite = true;
        }

        public bool WavesAreInfinite { get; }

        public bool CheatsAreEnabled { get; }
        
        public bool AutoHealIsOn { get; }

        public int WavesCount { get; }
    }
}