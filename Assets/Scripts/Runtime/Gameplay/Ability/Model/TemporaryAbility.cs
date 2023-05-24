using System;
using System.Threading.Tasks;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class TemporaryAbility : IAbility
    {
        private readonly IAbility _ability;
        private readonly float _seconds;

        public TemporaryAbility(IAbility ability, float seconds)
        {
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
            _seconds = seconds.ThrowIfLessOrEqualsToZeroException();
        }

        public bool IsActive => _ability.IsActive;

        public async void Activate()
        {
            _ability.Activate();
            await Task.Delay(TimeSpan.FromSeconds(_seconds));

            if (IsActive)
                Deactivate();
        }

        public void Deactivate()
        {
            _ability.Deactivate();
        }
    }
}