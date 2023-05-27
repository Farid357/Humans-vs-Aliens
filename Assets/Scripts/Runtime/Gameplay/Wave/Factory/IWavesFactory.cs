using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Gameplay
{
    public interface IWavesFactory
    {
        IWavesQueue Create();
    }
}