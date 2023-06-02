using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ChestWithView : MonoBehaviour, IChestWithView
    {
        [SerializeField] private ChestView _view;
        
        private IChest _chest;

        public void Init(IChest chest)
        {
            _chest = chest ?? throw new ArgumentNullException(nameof(chest));
        }
        
        public bool IsOpen => _chest.IsOpen;

        public bool IsActive => _view.IsActive;

        public void Open()
        {
            _chest.Open();
            _view.Open();
        }

        public void Destroy()
        {
            _view.Destroy();
        }
    }
}