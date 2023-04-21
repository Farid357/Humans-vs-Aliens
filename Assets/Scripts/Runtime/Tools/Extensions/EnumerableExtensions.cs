using System;
using System.Collections.Generic;
using System.Linq;

namespace HumansVsAliens.Tools
{
    public static class EnumerableExtensions
    {
        private static readonly Random _random = new Random();
        
        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) 
                throw new ArgumentNullException(nameof(enumerable));

            IEnumerable<T> toArray = enumerable as T[] ?? enumerable.ToArray();
            int randomIndex = _random.Next(0, toArray.Count());
            return toArray.ElementAt(randomIndex);
        }
    }
}