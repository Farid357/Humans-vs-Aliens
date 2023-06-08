namespace HumansVsAliens.Networking
{
    public interface IRoom : IReadOnlyRoom
    {
        void Join();

        void Leave();
    }
}