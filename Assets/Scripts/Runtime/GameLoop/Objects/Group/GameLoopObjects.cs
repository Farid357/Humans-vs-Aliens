using System;
using System.Collections.Generic;

namespace HumansVsAliens.GameLoop
{
    public sealed class GameLoopObjects : IGameLoopObjects
    {
        private readonly List<IGameLoopObject> _loopObjects;

        public GameLoopObjects(List<IGameLoopObject> loopObjects)
        {
            _loopObjects = loopObjects ?? throw new ArgumentNullException(nameof(loopObjects));
        }

        public GameLoopObjects() : this(new List<IGameLoopObject>())
        {
        }

        public void Add(IGameLoopObject loopObject)
        {
            _loopObjects.Add(loopObject);
        }

        public void Update(float deltaTime)
        {
            foreach (IGameLoopObject gameLoopObject in _loopObjects)
            {
                gameLoopObject.Update(deltaTime);
            }
        }
    }
}