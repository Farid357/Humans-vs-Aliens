using ExitGames.Client.Photon;
using HumansVsAliens.Networking;
using Photon.Pun;

namespace HumansVsAliens.Tools
{
    public static class NetworkExtensions
    {
        public static void SetScore(this INetworkPlayer player, int count)
        {
            player.SetCustomData(CustomProperties.Score, count);
        }

        public static int GetScore(this IReadOnlyNetworkPlayer player)
        {
            return (int)player.GetCustomData(CustomProperties.Score);
        }

        public static Hashtable ToRoomProperties(this IGameConfigurationSave save)
        {
            return new Hashtable()
            {
                { CustomProperties.WavesCount, save.WavesCount },
                { CustomProperties.CheatsAreEnabled, save.CheatsAreEnabled },
                { CustomProperties.WavesAreInfinite, save.WavesAreInfinite },
                { CustomProperties.AutoHealIsOn, save.AutoHealIsOn }
            };
        }

        public static IGameConfigurationSave GameConfiguration(this IReadOnlyNetwork network)
        {
            Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
            bool cheatsAreEnabled = (bool)properties[CustomProperties.CheatsAreEnabled];
            bool autoHealIsOn = (bool)properties[CustomProperties.AutoHealIsOn];

            if ((bool)properties[CustomProperties.WavesAreInfinite])
                return new GameConfigurationSave(cheatsAreEnabled, autoHealIsOn);

            return new GameConfigurationSave((int)properties[CustomProperties.WavesCount], cheatsAreEnabled, autoHealIsOn);
        }

        public static bool IsNotFull(this IReadOnlyRoom room)
        {
            return room.CurrentPlayersCount != room.MaxPlayersCount;
        }
    }
}