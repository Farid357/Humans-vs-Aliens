using System;

namespace HumansVsAliens.Tools
{
    public static class ComparableExtensions
    {
        public static int ThrowIfLessThanZeroException(this int number)
        {
            ThrowIfLessThanZeroException((float)number);
            return number;
        }

        public static float ThrowIfLessThanZeroException(this float number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException($"{number} less than zero!");

            return number;
        }

        public static int ThrowIfLessThanOrEqualsToZeroException(this int number)
        {
            ThrowIfLessOrEqualsToZeroException((float)number);
            return number;
        }

        public static float ThrowIfLessOrEqualsToZeroException(this float number)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            return number;
        }
    }
}