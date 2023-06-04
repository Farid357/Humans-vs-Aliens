namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyShop
    {
        IGoodViewData GetData(IGood good);
        
        int CalculatePrice(IGood good);
    }
}