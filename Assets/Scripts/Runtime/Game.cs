using System.Collections.Generic;
using HumansVsAliens.Factory;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Model;
using UnityEngine;

namespace HumansVsAliens
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        private IGameLoop _gameLoop;

        private void Awake()
        {
            _gameLoop = new GameLoop.GameLoop();
            ICharacter character = _characterFactory.Create();
            IGameLoopObject player = new Player(character);
            
            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player
            }));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}