using Photon.Pun;

namespace HumansVsAliens.UI
{
    public class JoinRandomRoomButton : IButton
    {
        public void Press()
        {
            if (PhotonNetwork.CountOfRooms > 0 && PhotonNetwork.IsConnected)
                PhotonNetwork.JoinRandomRoom();
        }
    }
}