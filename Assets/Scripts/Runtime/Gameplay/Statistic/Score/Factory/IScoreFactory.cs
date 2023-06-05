using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public interface IScoreFactory
    {
        IScore Create(IReadOnlyNetwork network);
    }
}