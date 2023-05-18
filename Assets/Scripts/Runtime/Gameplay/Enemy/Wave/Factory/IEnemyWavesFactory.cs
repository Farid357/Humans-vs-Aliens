using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Gameplay
{
    public interface IEnemyWavesFactory
    {
        IEnemyWavesQueue Create();
    }
}