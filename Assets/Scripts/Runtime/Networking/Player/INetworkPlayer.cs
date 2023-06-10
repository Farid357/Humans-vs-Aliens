namespace HumansVsAliens.Networking
{
    public interface INetworkPlayer : IReadOnlyNetworkPlayer
    {
        void SetCustomData(string key, object data);

        void SwitchName(string newName);
    }
}