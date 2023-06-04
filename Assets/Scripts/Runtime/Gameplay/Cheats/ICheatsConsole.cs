namespace HumansVsAliens.Gameplay
{
    public interface ICheatsConsole
    {
        ICommand GetCommand(string name);
       
        bool ContainsCommand(string name);
        
        void AddCommand(ICommand command, string name);
    }
}