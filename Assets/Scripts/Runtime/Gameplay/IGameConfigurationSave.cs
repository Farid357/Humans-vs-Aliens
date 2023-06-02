namespace HumansVsAliens
{
    public interface IGameConfigurationSave
    {
        bool WavesAreInfinite { get; }
        
        bool CheatsAreEnabled { get; }
        
        bool AutoHealIsOn { get; }
        
        int WavesCount { get; }
    }
}