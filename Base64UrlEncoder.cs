using System;
using System.Text;

namespace Kombit.Samples.Common
{
    public class Base64UrlEncoder
    {
        /// <summary>
        /// Encode string to base64url
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encode(string source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            string base64Str = Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
            char[] base64Chars = new char[base64Str.Length];
 
            // Replace "+" with "-", and "/" with "_"
            for (int pos = 0; pos < base64Str.Length; pos++)
            {
                char c = base64Str[pos];

                switch (c)
                {
                    case '+':
                        base64Chars[pos] = '-';
                        break;

                    case '/':
                        base64Chars[pos] = '_';
                        break;
                    default:
                        base64Chars[pos] = c;
                        break;
                }
            }
            return new string(base64Chars);
        }
    }
}
