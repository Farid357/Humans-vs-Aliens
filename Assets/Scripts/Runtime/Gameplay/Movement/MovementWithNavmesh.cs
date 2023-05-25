using UnityEngine;
using UnityEngine.AI;

namespace HumansVsAliens.Gameplay
{
    public sealed class MovementWithNavmesh : Movement
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MovementAnimations _animations;
        [SerializeField] private float _speed;
        
        public override Transform Transform => _agent.transform;

        public override void Move(Vector3 direction)
        {
            _agent.SetDestination(Transform.position + direction * _speed);
            _animations.PlayMove(direction);
        }
    }
}