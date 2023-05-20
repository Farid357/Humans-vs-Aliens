using Photon.Pun;

namespace HumansVsAliens.UI
{
    public class LeaveRoomButton : Button
    {
        protected override void Press()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}