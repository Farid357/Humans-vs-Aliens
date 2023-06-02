using ExitGames.Client.Photon;
using Photon.Realtime;

namespace HumansVsAliens.Tools
{
    public static class PhotonExtensions
    {
        public static void SetScore(this Player player, int count)
        {
            player.SetCustomProperties(new Hashtable() { { CustomProperties.Score, count } });
        }

        public static int GetScore(this Player player)
        {
            return (int)player.CustomProperties[CustomProperties.Score];
        }
    }
}