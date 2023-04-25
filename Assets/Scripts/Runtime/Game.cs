using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Factory;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Model;
using Photon.Pun;
using UnityEngine;
using Player = HumansVsAliens.Model.Player;

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
            InitLoots(character);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player
            }));
        }

        private void InitLoots(ICharacter character)
        {
            FindObjectsOfType<WeaponLoot>().ToList().ForEach(loot => loot.Init(character));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
            Debug.Log($"Player: {PhotonNetwork.PlayerList.Length}");
        }
    }
}