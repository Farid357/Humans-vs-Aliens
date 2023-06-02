using ExitGames.Client.Photon;
using HumansVsAliens.Networking;
using Photon.Pun;
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

        public static IGameConfigurationSave GameConfiguration(this INetwork network)
        {
            Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
            bool cheatsAreEnabled = (bool)properties[CustomProperties.CheatsAreEnabled];
            bool autoHealIsOn = (bool)properties[CustomProperties.AutoHealIsOn];
         
            if ((bool)properties[CustomProperties.WavesAreInfinite])
            {
                return new GameConfigurationSave(cheatsAreEnabled, autoHealIsOn);
            }

            else
            {
                return new GameConfigurationSave((int)properties[CustomProperties.WavesCount], cheatsAreEnabled, autoHealIsOn);
            }
        }
    }
}