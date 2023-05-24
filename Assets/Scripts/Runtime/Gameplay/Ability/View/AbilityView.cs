using UnityEngine;

namespace HumansVsAliens.View
{
    //TODO Replace with real view
    public class AbilityView : IAbilityView
    {
        public void Activate()
        {
            Debug.Log("Activated ability");
        }

        public void Deactivate()
        {
            Debug.Log("Deactivated ability");
        }
    }
}