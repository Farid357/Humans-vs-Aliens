using Photon.Pun;

namespace HumansVsAliens
{
    public class JoinRandomRoomButton : Button
    {
        protected override void Press()
        {
            if (PhotonNetwork.CountOfRooms > 0 && PhotonNetwork.IsConnected)
                PhotonNetwork.JoinRandomRoom();
        }
    }
}