namespace HumansVsAliens.Tools
{
    public static class StringExtensions
    {
        public static string DeleteWhiteSpaces(this string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == string.Empty)
                {
                    text.Remove(i);
                }
            }

            return text;
        }
    }
}