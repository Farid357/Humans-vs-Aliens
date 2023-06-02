namespace HumansVsAliens.Gameplay
{
    public interface IChest
    {
        bool IsOpen { get; }

        void Open();
    }
}