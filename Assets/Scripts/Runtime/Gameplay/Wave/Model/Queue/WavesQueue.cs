using System;
using System.Collections.Generic;
using System.Linq;

namespace HumansVsAliens.Gameplay
{
    public sealed class WavesQueue : IWavesQueue
    {
        private readonly Queue<IWave> _waves;
        private readonly IWave _lastWave;

        public WavesQueue(Queue<IWave> waves)
        {
            if (waves.Count == 0) 
                throw new ArgumentException("Value cannot be an empty collection.", nameof(waves));
            
            _waves = waves;
            _lastWave = _waves.Last();
        }
        
        public IWave GetWave()
        {
            return _waves.Count == 0 ? _lastWave : _waves.Dequeue();
        }
    }
}