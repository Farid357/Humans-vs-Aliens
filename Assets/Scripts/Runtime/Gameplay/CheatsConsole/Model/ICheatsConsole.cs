namespace HumansVsAliens.Gameplay
{
    public interface ICheatsConsole : IReadOnlyCheatsConsole
    {
        void ActivateCheat(string name);

        void AddCheat(ICheat cheat, string name);
    }
}