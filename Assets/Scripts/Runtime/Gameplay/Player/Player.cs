using System;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class Player : IPlayer
    {
        private readonly ICharacter _character;
        private readonly PlayerInput _input;

        public Player(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _input = new PlayerInput();
            _input.Enable();
        }

        public void Update(float deltaTime)
        {
            if (!_character.IsAlive)
                return;

            Vector2 moveDirection = _input.Movement.Move.ReadValue<Vector2>();
            Vector2 delta = _input.Camera.RotationDelta.ReadValue<Vector2>();
            
            _character.Movement.Move(new Vector3(moveDirection.x, 0, moveDirection.y));
            _character.Camera.Rotate(delta);
            
            if (_input.Movement.Jump.WasPerformedThisFrame() && _character.Movement.OnGround)
                _character.Movement.Jump();

            if (_input.Fighting.Attack.WasPerformedThisFrame() && moveDirection == Vector2.zero && _character.CanAttack)
                _character.Attack();

            if (_input.Camera.ZoomIn.IsPressed() && !_character.Camera.IsInFullZoomIn)
                _character.Camera.ZoomIn();

            if (!_input.Camera.ZoomIn.IsPressed() && !_character.Camera.IsInFullZoomOut)
                _character.Camera.ZoomOut();

            if (_input.Interaction.ChestOpening.IsPressed() && _character.CanOpenChest())
                _character.Chest().Open();
        }
    }
}