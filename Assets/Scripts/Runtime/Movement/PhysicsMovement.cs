using UnityEngine;

namespace HumansVsAliens.Model
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : Movement
    {
        [SerializeField, Min(0.01f)] private float _speed = 1.5f;

        private Rigidbody _rigidbody;
        
        public override Transform Transform => transform;

     
        private void OnEnable()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }


        public override void Move(Vector3 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * Time.fixedDeltaTime * _speed);
        }
    }
}