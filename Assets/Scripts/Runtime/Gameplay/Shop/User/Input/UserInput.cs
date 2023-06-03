using System;
using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HumansVsAliens.Gameplay
{
    public class UserInput : IUserInput, IGameLoopObject
    {
        private readonly GraphicRaycaster _physicsRaycaster;
        private IGood _good;

        public UserInput(GraphicRaycaster physicsRaycaster)
        {
            _physicsRaycaster = physicsRaycaster;
        }

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
            if (!Mouse.current.leftButton.isPressed)
                return;

            var results = new List<RaycastResult>();
            var pointerEventData = new PointerEventData(null);
            pointerEventData.position = Mouse.current.position.ReadValue();
            _physicsRaycaster.Raycast(pointerEventData, results);

            foreach (var result in results)
            {
                if (result.gameObject.TryGetComponent(out IGood good))
                    _good = good;
            }
        }
    }
}