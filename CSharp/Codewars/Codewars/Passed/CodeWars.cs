using System;
using System.Security.Cryptography;
using System.Text;

namespace Codewars.Codewars.Passed
{
    public class CodeWars
    {
        private static HashAlgorithm Hasher = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5"));
    
        public static string crack(string hash)
        {
            for (var i = 0; i < 100000; i++)
            {
                var p = i.ToString("00000");
                var h = GetHash(p);
                if (h == hash)
                {
                    return p;
                }
            }
            return "";
        }

        public static string GetHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hash = Hasher.ComputeHash(bytes);
            var encoded = BitConverter.ToString(hash)
                                      .Replace("-", string.Empty)
                                      .ToLower();

            return encoded;
        }
    }
}
