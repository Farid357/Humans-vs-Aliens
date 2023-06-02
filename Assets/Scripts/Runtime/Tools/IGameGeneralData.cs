using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public interface IGameGeneralData
    {
        IGameConfigurationSave GameConfiguration { get; }
    }
}