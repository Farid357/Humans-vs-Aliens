using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Model
{
    public class PrepareGameCommand : IServerCommand
    {
        private readonly IEnemyWave _wave;

        public PrepareGameCommand(IEnemyWave wave)
        {
            _wave = wave ?? throw new ArgumentNullException(nameof(wave));
        }

        public void Execute()
        {
            _wave.Start();
        }
    }
}