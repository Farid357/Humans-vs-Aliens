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
            if (loopObject == null)
                throw new ArgumentNullException(nameof(loopObject));
            
            _loopObjects.Add(loopObject);
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < _loopObjects.Count; i++)
            {
                IGameLoopObject loopObject = _loopObjects[i];
                loopObject.Update(deltaTime);
            }
        }
    }
}