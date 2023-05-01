using HumansVsAliens.Model;

namespace HumansVsAliens.Factory
{
    public interface IEnemyWavesFactory
    {
        IEnemyWavesQueue Create();
    }
}