using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens
{
    public class RoomData : IRoomData
    {
        public RoomData(int currentPlayersCount, int maxPlayersCount, string name)
        {
            CurrentPlayersCount = currentPlayersCount.ThrowIfLessThanOrEqualsToZeroException();
            MaxPlayersCount = maxPlayersCount.ThrowIfLessThanOrEqualsToZeroException();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public int CurrentPlayersCount { get; }
        
        public int MaxPlayersCount { get; }
        
        public string Name { get; }
    }
}