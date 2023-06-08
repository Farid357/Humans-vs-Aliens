namespace HumansVsAliens.Gameplay
{
    public interface IChestFactory
    {
        IChestWithView CreateLocal();
        
        IChestWithView Create();
    }
}