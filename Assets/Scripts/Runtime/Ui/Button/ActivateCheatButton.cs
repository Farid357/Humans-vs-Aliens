using System;
using HumansVsAliens.UI;

namespace HumansVsAliens.Gameplay
{
    public sealed class ActivateCheatButton : IButton
    {
        private readonly ICheatsConsole _cheatsConsole;
        private readonly IInputField _inputField;

        public ActivateCheatButton(ICheatsConsole cheatsConsole, IInputField inputField)
        {
            _cheatsConsole = cheatsConsole ?? throw new ArgumentNullException(nameof(cheatsConsole));
            _inputField = inputField ?? throw new ArgumentNullException(nameof(inputField));
        }

        public void Press()
        {
            string commandName = _inputField.Text;
            
            if (_cheatsConsole.ContainsCommand(commandName))
            {
                ICommand command = _cheatsConsole.GetCommand(commandName);
                command.Execute();
            }
        }
    }
}