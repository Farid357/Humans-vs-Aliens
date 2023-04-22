using System;
using HumansVsAliens.LoadSystem;
using HumansVsAliens.Networking;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        private IRoom _room;
        
        private void Awake()
        {
            INetwork network = new Network();
            _room = new Room(_game);
            network.Connect();
        }
        
        public void JoinRoom()
        {
            Debug.Log("try Joined");
            _room.JoinRandom();
        }

        public void CreateRoom()
        {
            _room.EnterInNew();
        }
    }
}