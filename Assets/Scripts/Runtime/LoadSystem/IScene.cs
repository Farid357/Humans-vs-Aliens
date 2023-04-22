namespace HumansVsAliens.LoadSystem
{
    public interface IScene
    {
        string Name { get; }
        
        void Load();

        void Unload();
    }
}