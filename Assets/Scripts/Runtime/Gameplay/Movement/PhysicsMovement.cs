using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : Movement
    {
        [SerializeField] private MovementAnimations _animations;
        [SerializeField, Min(0.01f)] private float _speed = 1.5f;

        private Rigidbody _rigidbody;
        
        public override Vector3 Position => _rigidbody.position;
     
        private void OnEnable()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        public override void Move(Vector3 direction)
        {
            Vector3 offset = direction * Time.fixedDeltaTime * _speed;
            _rigidbody.MovePosition(Position + offset);
            _animations.PlayMove(direction.normalized);
        }
    }
}