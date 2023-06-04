using System;
using System.Collections.Generic;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class CheatsConsole : ICheatsConsole
    {
        private readonly IDictionary<string, ICommand> _commands;

        public CheatsConsole(IDictionary<string, ICommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public CheatsConsole() : this(new Dictionary<string, ICommand>())
        {
        }

        public ICommand GetCommand(string name)
        {
            return _commands[name.DeleteWhiteSpaces()];
        }

        public bool ContainsCommand(string name)
        {
            return _commands.ContainsKey(name.DeleteWhiteSpaces());
        }

        public void AddCommand(ICommand command, string name)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            
            if (name == null) 
                throw new ArgumentNullException(nameof(name));
            
            _commands.Add(name.DeleteWhiteSpaces(), command);
        }
    }
}