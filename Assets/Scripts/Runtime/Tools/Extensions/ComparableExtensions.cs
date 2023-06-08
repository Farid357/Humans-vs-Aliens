using System;
using UnityEngine;

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

        public static int ToInt(this string text)
        {
            text = text.DeleteWhiteSpaces();
            return int.Parse(text);
        }

        public static float ToFloat(this string text)
        {
            text = text.DeleteWhiteSpaces();
            return float.Parse(text);
        }

        public static float ToAudioVolume(this float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            return Mathf.Lerp(-25, 20, value);
        }
    }
}