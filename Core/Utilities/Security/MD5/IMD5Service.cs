using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.MD5
{
    public interface IMD5Service
    {
        /// <summary>
        /// Metni MD'e Dönüştür
        /// </summary>
        /// <param name="text">string text</param>
        /// <returns>string text</returns>
        string ConvertTextToMD5(string text);

        /// <summary>
        /// MD5 ile Şifreleme
        /// </summary>
        /// <param name="text">string text</param>
        /// <returns>string text</returns>
        string Encrypt(string text);

        /// <summary>
        /// Şifresini Çöz (MD5)
        /// </summary>
        /// <param name="encryptedValue">string MD5</param>
        /// <returns>string text</returns>
        string Decrypt(string encryptedValue);
    }
}