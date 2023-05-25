using ExitGames.Client.Photon;
using Photon.Realtime;

namespace HumansVsAliens.Tools
{
    public static class PhotonExtensions
    {
        private const string ScoreProperty = "Score";

        public static void SetScore(this Player player, int count)
        {
            player.SetCustomProperties(new Hashtable() { { ScoreProperty, count } });
        }

        public static int GetScore(this Player player)
        {
            return (int)player.CustomProperties[ScoreProperty];
        }
    }
}