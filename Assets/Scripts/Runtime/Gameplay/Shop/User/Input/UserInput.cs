using System;
using HumansVsAliens.GameLoop;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HumansVsAliens.Gameplay
{
    public class UserInput : IUserInput, IGameLoopObject
    {
        private IGood _good;

        public bool HasGood => _good != null;

        public IGood Good
        {
            get
            {
                if (!HasGood)
                    throw new InvalidOperationException(nameof(HasGood));

                return _good;
            }
        }

        public void Update(float deltaTime)
        {
            if (!Mouse.current.IsPressed()) 
                return;
            
            if (Physics.Raycast(Vector3.zero, Vector3.forward, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IGood good))
                {
                    _good = good;
                }
            }
        }
    }
}