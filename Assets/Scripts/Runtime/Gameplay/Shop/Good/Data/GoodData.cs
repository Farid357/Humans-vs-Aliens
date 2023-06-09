using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [CreateAssetMenu(menuName = "Create/Good", fileName = "Good", order = 0)]
    public class GoodData : ScriptableObject, IGoodData
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: SerializeField, TextArea] public string Description { get; private set; }

        [field: SerializeField, Range(1, 100000)] public int Price { get; private set; }
    }
}