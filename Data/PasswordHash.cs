﻿using System.Security.Cryptography;

namespace asp_pro.Data
{
    public class PasswordHash
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int sizeSalt = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[sizeSalt]);
            var key = new Rfc2898DeriveBytes(password , salt , Iterations);
            var hash = key.GetBytes(HashSize);
            var hashBytes = new Byte[sizeSalt+ HashSize];
            Array.Copy(salt, 0, hashBytes ,0,sizeSalt);
            Array.Copy(hash, 0, hashBytes ,sizeSalt, HashSize);
            var base64Hash = Convert.ToBase64String(hashBytes);
            return base64Hash;
        }
        public static bool VerifyPassword(string password , string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);
            var salt = new byte[sizeSalt];
            Array.Copy(hashBytes , 0, salt, 0, sizeSalt);
            var key = new Rfc2898DeriveBytes(password, salt , Iterations);
            byte[] hash = key.GetBytes(HashSize);
            for(var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i+sizeSalt] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
