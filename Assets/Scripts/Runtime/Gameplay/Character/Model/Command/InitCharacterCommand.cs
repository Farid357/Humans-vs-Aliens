using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public class InitCharacterCommand : IServerCommand
    {
        private readonly IHealth _health;
        private readonly IBladedWeaponsCollection _weaponsCollection;
        private readonly Character _character;

        public InitCharacterCommand(IHealth health, IBladedWeaponsCollection weaponsCollection, Character character)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _weaponsCollection = weaponsCollection ?? throw new ArgumentNullException(nameof(weaponsCollection));
            _character = character ? character : throw new ArgumentNullException(nameof(character));
        }

        public void Execute()
        {
            _character.Init(_health, _weaponsCollection);
        }
    }
}