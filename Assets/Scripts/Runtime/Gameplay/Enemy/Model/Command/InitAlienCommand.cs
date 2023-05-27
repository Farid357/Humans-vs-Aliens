using HumansVsAliens.Networking;
using System;

namespace HumansVsAliens.Gameplay
{
    public class InitAlienCommand : IServerCommand
    {
        private readonly IHealth _health;
        private readonly Alien _alien;

        public InitAlienCommand(IHealth health, Alien alien)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _alien = alien ? alien : throw new ArgumentNullException(nameof(alien));
        }

        public void Execute()
        {
            _alien.Init(_health);
        }
    }
}