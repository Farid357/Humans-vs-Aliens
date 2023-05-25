using Photon.Pun;

namespace HumansVsAliens.UI
{
    public class LeaveRoomButton : IButton
    {
        public void Press()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}