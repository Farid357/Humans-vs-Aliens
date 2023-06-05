namespace HumansVsAliens.Networking
{
    public interface IReadOnlyNetworkPlayer
    {
        object GetCustomData(string key);

        string Name { get; }
    }
}