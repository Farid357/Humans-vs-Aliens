using System;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class HealthExtensions
    {
        public static bool IsDied(this IReadOnlyHealth health)
        {
            return health.IsAlive == false;
        }

        public static void Kill(this IHealth health)
        {
            if (health.IsDied())
                throw new InvalidOperationException($"Health is died!");
            
            health.TakeDamage(health.Value);
        }

        public static void Heal(this IHealth health, int maxValue = 100)
        {
            health.Heal(maxValue - health.Value);
        }
    }
}