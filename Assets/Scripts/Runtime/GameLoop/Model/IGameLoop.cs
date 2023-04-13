namespace HumansVsAliens.GameLoop
{
    public interface IGameLoop : IGameLoopObjectsGroup
    {
        void Update(float deltaTime);
    }
}