using UnityEngine;
using Sirenix.OdinInspector;

namespace HumansVsAliens.View
{
    [CreateAssetMenu(menuName = "Create/WeaponViewData", fileName = "Data", order = 0)]
    public sealed class BladedWeaponViewData : ScriptableObject, IBladedWeaponViewData
    {
        [field: SerializeField, TextArea] public string Name { get; private set; }
        
       
        [field: SerializeField, HideLabel, Title("Icon", bold: true), PreviewField]
        public Sprite Icon { get; private set; }

    }
}