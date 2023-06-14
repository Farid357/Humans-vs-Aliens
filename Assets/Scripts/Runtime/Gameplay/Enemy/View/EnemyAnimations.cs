using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class EnemyAnimations : MonoBehaviour, IEnemyAnimations
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string[] _attacks;
        
        public void PlayAttack()
        {
            string randomAttack = _attacks.GetRandom();
            _animator.Play(randomAttack);
        }
    }
}