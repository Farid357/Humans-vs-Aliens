using UnityEngine;

namespace HumansVsAliens.View
{
    [CreateAssetMenu(menuName = "Create/WeaponViewData", fileName = "Data", order = 0)]
    public sealed class BladedWeaponViewData : ScriptableObject, IBladedWeaponViewData
    {
        [field: SerializeField] public string Name { get; private set; }
        
        [field: SerializeField] public Sprite Icon { get; private set; }

    }
}