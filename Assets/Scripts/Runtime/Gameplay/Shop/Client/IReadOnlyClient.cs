namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyClient
    {
        bool HasEnoughMoney { get; }

        bool HasGood { get; }
    }
}