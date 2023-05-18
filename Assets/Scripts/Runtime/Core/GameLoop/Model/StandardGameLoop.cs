using System;

namespace HumansVsAliens.GameLoop
{
    public sealed class StandardGameLoop : IGameLoop
    {
        private readonly IGameLoopObjects _loopObjects;

        public StandardGameLoop()
        {
            _loopObjects = new GameLoopObjects();
        }

        public void Update(float deltaTime)
        {
            _loopObjects.Update(deltaTime);
        }

        public void Add(IGameLoopObject loopObject)
        {
            if (loopObject == null)
                throw new ArgumentNullException(nameof(loopObject));
            
            _loopObjects.Add(loopObject);
        }
    }
}