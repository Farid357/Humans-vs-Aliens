using System;
using HumansVsAliens.UI;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public sealed class ActivateCheatButton : IButton
    {
        private readonly ICheatsConsole _cheatsConsole;
        private readonly ICheatsConsoleView _cheatsConsoleView;
        private readonly IInputField _inputField;

        public ActivateCheatButton(ICheatsConsole cheatsConsole, ICheatsConsoleView cheatsConsoleView, IInputField inputField)
        {
            _cheatsConsole = cheatsConsole ?? throw new ArgumentNullException(nameof(cheatsConsole));
            _cheatsConsoleView = cheatsConsoleView ?? throw new ArgumentNullException(nameof(cheatsConsoleView));
            _inputField = inputField ?? throw new ArgumentNullException(nameof(inputField));
        }

        public void Press()
        {
            string commandName = _inputField.Text;

            if (_cheatsConsole.ContainsCheat(commandName))
            {
                _cheatsConsole.ActivateCheat(commandName);
            }
            
            else if(commandName == "/")
            {
                _cheatsConsoleView.Show(_cheatsConsole.CheatNames);
            }
        }
    }
}