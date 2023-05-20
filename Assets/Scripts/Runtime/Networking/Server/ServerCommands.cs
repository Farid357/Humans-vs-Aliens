using System;
using System.Collections.Generic;

namespace HumansVsAliens.Networking
{
    public class ServerCommands : IServerCommand
    {
        private readonly IReadOnlyList<IServerCommand> _all;

        public ServerCommands(IReadOnlyList<IServerCommand> all)
        {
            if (all.Count == 0)
                throw new ArgumentOutOfRangeException($"Commands list is empty!");

            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public void Execute()
        {
            foreach (IServerCommand command in _all)
            {
                command.Execute();
            }
        }
    }
}