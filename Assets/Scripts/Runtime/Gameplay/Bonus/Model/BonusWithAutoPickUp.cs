using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class BonusWithAutoPickUp : MonoBehaviour, IBonus
    {
        [SerializeField] private BonusView _view;

        private readonly Collider[] _colliders = new Collider[30];
        private IBonus _bonus;

        public IBonusView View => _view;
        
        public bool CanBePicked => _bonus.CanBePicked;

        public void Init(IBonus bonus)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
        }

        private void Update()
        {
            if (!CanBePicked)
                return;

            Physics.OverlapSphereNonAlloc(transform.position, 1.2f, _colliders);

            foreach (Collider collider in _colliders)
            {
                if (collider != null && collider.TryGetComponent(out IReadOnlyCharacter _))
                    PickUp();
            }
        }

        public void PickUp()
        {
            _bonus.PickUp();
        }
    }
}