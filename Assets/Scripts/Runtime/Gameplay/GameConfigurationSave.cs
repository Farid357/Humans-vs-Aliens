using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens
{
    public sealed class GameConfigurationSave : ISaveObject, IGameConfigurationSave
    {
        private int _wavesCount;

        public GameConfigurationSave()
        {
            
        }
        
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

        public bool WavesAreInfinite { get; private set; }

        public bool CheatsAreEnabled { get; private set; }
        
        public bool AutoHealIsOn { get; private set; }

        public int WavesCount
        {
            get
            {
                if (WavesAreInfinite)
                    throw new InvalidOperationException($"Waves are infinite!");

                return _wavesCount;
            }
        }

        public void Serialize(ISaveHandle saveHandle)
        {
            saveHandle.WriteBool(AutoHealIsOn);
            saveHandle.WriteBool(CheatsAreEnabled);
            saveHandle.WriteBool(WavesAreInfinite);
            saveHandle.WriteInt(_wavesCount);
        }

        public void Deserialize(ISaveHandle saveHandle)
        {
           AutoHealIsOn =  saveHandle.ReadBool();
           CheatsAreEnabled = saveHandle.ReadBool();
           WavesAreInfinite = saveHandle.ReadBool();
           _wavesCount = saveHandle.ReadInt();
        }
    }
}