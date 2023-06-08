using System;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;

namespace HumansVsAliens.UI
{
    public class LeaveRoomButton : IButton
    {
        private readonly INetwork _network;

        public LeaveRoomButton(INetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }

        public void Press()
        {
            _network.LeaveRoom();
        }
    }
}