using System;
using HumansVsAliens.Model;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public class AlienFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Alien _alienPrefab;
        [SerializeField] private int _health = 80;
        
        private IReadOnlyCharacter _character;

        public void Init(IReadOnlyCharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public IEnemy Create(Vector3 position)
        {
            Alien alien = PhotonNetwork.Instantiate(_alienPrefab.name, position, Quaternion.identity).GetComponent<Alien>();
            IHealthView healthView = new AlienHealthView(alien.gameObject);
            IHealth health = new Health(healthView, _health);
            alien.Init(_character, health);
            return alien;
        }
    }
}