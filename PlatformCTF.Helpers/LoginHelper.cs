using System;
using System.Security.Cryptography;
using System.Text;

namespace PlatformCTF.Helpers
{
    public class LoginHelper
    {
        public static string SaltGen()
        {
            var salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return BitConverter.ToString(salt).Replace("-", "").ToLower();
        }
        public static string HashGen(string password)
        {
            string salt = SaltGen();
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + salt);
            var encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
        }
    }
}