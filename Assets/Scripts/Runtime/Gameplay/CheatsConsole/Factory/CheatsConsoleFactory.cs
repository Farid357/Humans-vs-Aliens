using HumansVsAliens.UI;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CheatsConsoleFactory : MonoBehaviour
    {
        [SerializeField] private Window _cheatsWindow;
        [SerializeField] private UnityButton _activateCheatButton;
        [SerializeField] private InputField _cheatsInputField;
        [SerializeField] private CheatsConsoleView _consoleView;
        
        public ICheatsConsole Create(IReadOnlyCharacter character, ICharacterStatistics statistics)
        {
            ICheatsConsole console = new CheatsConsole();
            
            console.AddCheat(new HealCheat(character.Health, 25), "HealCharacter");
            console.AddCheat(new PutMoneyCheat(statistics.Wallet, 1000), "AddMoney");
            
            _activateCheatButton.Init(new ActivateCheatButton(console, _consoleView, _cheatsInputField));
            _cheatsWindow.Open();
            return console;
        }
    }
}