using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class PopupAutoOpen : MonoBehaviour
    {
        [SerializeField] private Window _popup;

        private ICharacterSearcher _characterSearcher;

        private void Awake()
        {
            _characterSearcher = new CharacterSearcher(transform, 4f);
        }

        private void Update()
        {
            _characterSearcher.Search();

            if (_characterSearcher.HasFoundCharacter)
            {
                _popup.Open();
            }

            else
            {
                _popup.Close();
            }
        }
    }
}