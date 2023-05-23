using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class PhysicsBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private BonusView _view;
       
        private IBonus _bonus;

        public IBonusView View => _view;

        public void Init(IBonus bonus)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
        }
        
        private void OnTriggerEnter(Collider collider)
        {
            if(collider.TryGetComponent(out IReadOnlyCharacter _))
                _bonus.PickUp();
        }

        public void PickUp()
        {
            _bonus.PickUp();
        }
    }
}