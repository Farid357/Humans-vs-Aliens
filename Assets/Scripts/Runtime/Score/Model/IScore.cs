namespace HumansVsAliens.Model
{
    public interface IScore
    {
        int Count { get; }

        void Add(int count);
    }
}