using System.Collections.Generic;

namespace HumansVsAliens.View
{
    public interface ICheatsConsoleView
    {
        void Show(IEnumerable<string> cheatNames);
    }
}