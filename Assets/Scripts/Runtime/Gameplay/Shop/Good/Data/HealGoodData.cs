using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [CreateAssetMenu(menuName = "Create/Heal Good", fileName = "Heal Good", order = 0)]
    public class HealGoodData : GoodData
    {
        [field: SerializeField, Min(10)] public int Heal { get; private set; }
    }
}