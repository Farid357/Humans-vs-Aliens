using System;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class HealthExtensions
    {
        public static bool IsDied(this IHealth health)
        {
            return health.IsAlive == false;
        }

        public static void Kill(this IHealth health)
        {
            if (health.IsDied())
                throw new InvalidOperationException($"Health is died!");
            
            health.TakeDamage(health.Value);
        }
    }
}