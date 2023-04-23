using UnityEngine;

namespace HumansVsAliens
{
    public class Window : MonoBehaviour
    {
        public bool IsActive => gameObject.activeInHierarchy;
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

    }
}