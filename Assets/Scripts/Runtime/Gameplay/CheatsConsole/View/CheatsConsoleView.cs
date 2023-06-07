using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CheatsConsoleView : MonoBehaviour, ICheatsConsoleView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Window _commandsWindow;

        private readonly StringBuilder _stringBuilder = new();
        
        public async void Show(IEnumerable<string> cheatNames)
        {
            foreach (string name in cheatNames)
            {
                _stringBuilder.Append(name + "\n");
            }
            
            _commandsWindow.Open();
            _text.text = _stringBuilder.ToString();
            _stringBuilder.Clear();
            
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            
            _text.text = string.Empty;
            _commandsWindow.Close();
        }
    }
}