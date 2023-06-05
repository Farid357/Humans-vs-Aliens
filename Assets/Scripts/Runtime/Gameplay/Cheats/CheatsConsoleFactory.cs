using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CheatsConsoleFactory : MonoBehaviour
    {
        [SerializeField] private Window _cheatsWindow;
        [SerializeField] private UnityButton _activateCheatButton;
        [SerializeField] private InputField _cheatsInputField;
        
        public ICheatsConsole Create(IReadOnlyCharacter character, ICharacterStatistics statistics)
        {
            _cheatsWindow.Open();
            ICheatsConsole console = new CheatsConsole();
            
            console.AddCommand(new HealCommand(character.Health, 25), "HealCharacter");
            console.AddCommand(new PutMoneyCommand(statistics.Wallet, 1000), "AddMoney");
            
            _activateCheatButton.Init(new ActivateCheatButton(console, _cheatsInputField));
            return console;
        }
    }
}