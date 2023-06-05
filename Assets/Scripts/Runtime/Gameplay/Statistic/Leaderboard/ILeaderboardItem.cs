using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public interface ILeaderboardItem
    {
        void Visualize(IReadOnlyNetworkPlayer player);
    }
}