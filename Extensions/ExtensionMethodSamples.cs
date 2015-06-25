using System.Collections.Generic;

namespace Training.Csharp.Extensions
{
    public static class ExtensionMethodSamples
    {
        //Extend string class
        public static string MyStringManipulation(this string text)
        {
            if(string.IsNullOrEmpty(text))
                return text;

            return text.Trim("!".ToCharArray()).Replace(" ", string.Empty).ToUpper();
        }

        //Extend Interface IList<T>
        public static int MyCount<T>(this IList<T> collection) where T : class
        {
            if (collection.Count >= 1)
                return 1;
            else
                return 0;
        }
    }
}
