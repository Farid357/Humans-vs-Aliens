using Photon.Pun;

namespace HumansVsAliens.Tools
{
    public sealed class GameGeneralData : IGameGeneralData
    {
        public GameGeneralData()
        {
            GameConfiguration = (GameConfigurationSave)PhotonNetwork.CurrentRoom.CustomProperties[CustomProperties.GameConfiguration];
        }

        public IGameConfigurationSave GameConfiguration { get; }
    }
}