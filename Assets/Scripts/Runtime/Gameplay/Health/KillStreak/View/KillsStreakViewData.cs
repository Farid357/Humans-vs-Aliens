using System;
using UnityEngine;

namespace HumansVsAliens.View
{
    [Serializable]
    public struct KillsStreakViewData
    {
        [field: SerializeField] public Color32 Color { get; private set; }

        [field: SerializeField] public int KillStreak { get; private set; }
    }
}