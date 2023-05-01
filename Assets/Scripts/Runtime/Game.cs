using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;
using HumansVsAliens.Factory;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Model;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using Photon.Pun;
using UnityEngine;
using Player = HumansVsAliens.Model.Player;

namespace HumansVsAliens
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private ScoreFactory _scoreFactory;

        private byte _commandCode = 1;
        private IGameLoop _gameLoop;

        private async void Awake()
        {
            _gameLoop = new GameLoop.GameLoop();
            ICharacter character = _characterFactory.Create();
            IScore score = _scoreFactory.Create();
            IGameLoopObject player = new Player(character);
            var server = new Server<IScore>();
            InitLoots(character);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
            }));

            await UniTask.Delay(3000);
            server.SendCommandToClients(new AddScoreCommand(score));
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