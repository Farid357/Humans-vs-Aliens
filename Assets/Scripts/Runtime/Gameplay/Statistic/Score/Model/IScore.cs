namespace HumansVsAliens.Gameplay
{
    public interface IScore
    {
        int Count { get; }

        void Add(int count);
    }
}