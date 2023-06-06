using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyCheatsConsole
    {
        IEnumerable<string> CheatNames { get; }
        
        bool ContainsCheat(string name);
    }
}