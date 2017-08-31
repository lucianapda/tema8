using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TrabalhoBackEnd.Util
{
    public static class Utils
    {
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public static short ObterValor(this Enum value)
        {
            return Convert.ToInt16(value);
        }

        public static bool HasFlag<T>(this Enum value, string item)
        {
            var valorEnum = (Enum)Enum.Parse(typeof(T), item, true);
            return value.HasFlag(valorEnum);
        }
    }
}