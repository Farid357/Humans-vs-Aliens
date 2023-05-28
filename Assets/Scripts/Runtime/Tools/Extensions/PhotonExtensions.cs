using System;
using ExitGames.Client.Photon;
using HumansVsAliens.Networking;
using Photon.Pun;
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

        public static RpcTarget ToPhoton(this ServerCommandReceivers receivers)
        {
            return receivers switch
            {
                ServerCommandReceivers.Clients => RpcTarget.All,
                ServerCommandReceivers.Server => RpcTarget.MasterClient,
                _ => throw new ArgumentOutOfRangeException(nameof(receivers), receivers, null)
            };
        }
    }
}