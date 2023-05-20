using HumansVsAliens.Networking;
using System;

namespace HumansVsAliens.Gameplay
{
    public class InitAlienCommand : IServerCommand
    {
        private readonly IReadOnlyCharacter _character;
        private readonly IHealth _health;
        private readonly Alien _alien;

        public InitAlienCommand(IReadOnlyCharacter character, IHealth health, Alien alien)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _alien = alien ?? throw new ArgumentNullException(nameof(alien));
        }

        public void Execute()
        {
            _alien.Init(_character, _health);
        }
    }
}