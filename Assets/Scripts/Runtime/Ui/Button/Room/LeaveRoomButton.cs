using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.UI
{
    public class LeaveRoomButton : IButton
    {
        private readonly IRoom _room;

        public LeaveRoomButton(IRoom room)
        {
            _room = room ?? throw new ArgumentNullException(nameof(room));
        }

        public void Press()
        {
            _room.Leave();
        }
    }
}