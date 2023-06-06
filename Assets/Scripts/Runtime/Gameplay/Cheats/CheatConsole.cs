using System;
using System.Collections.Generic;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class CheatsConsole : ICheatsConsole
    {
        private readonly IDictionary<string, ICheat> _commands;

        public CheatsConsole(IDictionary<string, ICheat> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public CheatsConsole() : this(new Dictionary<string, ICheat>())
        {
        }

        public IEnumerable<string> CheatNames => _commands.Keys;
        
        public void ActivateCheat(string name)
        {
            if (ContainsCheat(name) == false)
                throw new InvalidOperationException(nameof(ContainsCheat));
            
            _commands[name.DeleteWhiteSpaces()].Activate();
        }


        public bool ContainsCheat(string name)
        {
            return _commands.ContainsKey(name.DeleteWhiteSpaces());
        }

        public void AddCheat(ICheat cheat, string name)
        {
            if (cheat == null)
                throw new ArgumentNullException(nameof(cheat));
            
            if (name == null) 
                throw new ArgumentNullException(nameof(name));
            
            _commands.Add(name.DeleteWhiteSpaces(), cheat);
        }
    }
}