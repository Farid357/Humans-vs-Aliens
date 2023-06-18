using System.Collections.Generic;

namespace HumansVsAliens.Networking
{
    public interface IRoomsCollection
    {
        IRoom CurrentRoom { get; }
        
        IReadOnlyList<IRoom> Rooms { get; }
    }
}