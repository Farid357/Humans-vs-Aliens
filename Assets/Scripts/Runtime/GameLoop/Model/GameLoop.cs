namespace HumansVsAliens.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IGameLoopObjects _loopObjects;

        public GameLoop()
        {
            _loopObjects = new GameLoopObjects();
        }

        public void Update(float deltaTime)
        {
            _loopObjects.Update(deltaTime);
        }

        public void Add(IGameLoopObject loopObject)
        {
            _loopObjects.Add(loopObject);
        }
    }
}