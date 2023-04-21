using UnityEngine;
using UnityEngine.AI;

namespace HumansVsAliens.Model
{
    public sealed class MovementWithNavmesh : MonoBehaviour, IMovement
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MovementAnimations _animations;
        [SerializeField] private float _speed;
        
        public Transform Transform => _agent.transform;

        public void Move(Vector3 direction)
        {
            _agent.Move(direction * _speed);
            _animations.PlayMove(direction);
        }
    }
}