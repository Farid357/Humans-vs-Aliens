using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyFactories : MonoBehaviour
    {
        [SerializeField] private AlienFactory _alienFactory;
        [SerializeField] private AlienFactory _redAlienFactory;

        public void Init(IReadOnlyCharacter character, IGameLoopObjectsGroup gameLoop,
            ICharacterStatistics statistics, IServer server)
        {
            _alienFactory.Init(character, gameLoop, statistics, server);
            _redAlienFactory.Init(character, gameLoop, statistics, server);
        }

        public IReadOnlyDictionary<EnemyType, IEnemyFactory> Create()
        {
            IReadOnlyDictionary<EnemyType, IEnemyFactory> factories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Alien, _alienFactory },
                { EnemyType.RedAlien, _redAlienFactory }
            };

            return factories;
        }
    }
}