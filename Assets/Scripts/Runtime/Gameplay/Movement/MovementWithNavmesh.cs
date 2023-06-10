using UnityEngine;
using UnityEngine.AI;

namespace HumansVsAliens.Gameplay
{
    public sealed class MovementWithNavmesh : Movement
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MovementAnimations _animations;
        [SerializeField] private float _speed = 2f;
        
        public override Vector3 Position => _agent.transform.position;

        public override void Move(Vector3 direction)
        {
            _agent.SetDestination(Position + direction * _speed);
            _animations.PlayMove(direction);
        }
    }
}