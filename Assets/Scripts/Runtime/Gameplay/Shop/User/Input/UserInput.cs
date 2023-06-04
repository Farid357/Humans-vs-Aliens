using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HumansVsAliens.Gameplay
{
    public class UserInput : IUserInput
    {
        private readonly GraphicRaycaster _physicsRaycaster;
        private IGood _good;

        public UserInput(GraphicRaycaster physicsRaycaster)
        {
            _physicsRaycaster = physicsRaycaster;
        }

        public IGood Good => _good ?? throw new InvalidOperationException(nameof(ClickedOnGood));

        public bool ClickedOnGood()
        {
            if (!Mouse.current.leftButton.isPressed)
                return false;

            var results = new List<RaycastResult>();
            var pointerEventData = new PointerEventData(null);
            pointerEventData.position = Mouse.current.position.ReadValue();
            _physicsRaycaster.Raycast(pointerEventData, results);

            foreach (var result in results)
            {
                if (result.gameObject.TryGetComponent(out IGood good))
                {
                    _good = good;
                    return true;
                }
            }

            return false;
        }
    }
}