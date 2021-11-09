using System;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hash.Sha256
{
    public class Sha256HashService : IHashService
    {
        public string CreateHash(string plainText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool CompareHash(string hashedText, string plainText)
        {
            return CreateHash(plainText) == hashedText;
        }
    }
}