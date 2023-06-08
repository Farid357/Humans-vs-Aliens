using System;
using System.Linq;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;

namespace HumansVsAliens.UI
{
    public class JoinRandomRoomButton : IButton
    {
        private readonly IReadOnlyNetwork _network;

        public JoinRandomRoomButton(IReadOnlyNetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }

        public void Press()
        {
            if (_network.Rooms.Count == 0 || !_network.IsConnected)
                return;

            IRoom randomRoom = _network.Rooms.Where(room => room.IsNotFull()).GetRandom();
            randomRoom?.Join();
        }
    }
}