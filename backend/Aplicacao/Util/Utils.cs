using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Aplicacao.Util
{
    public static class Utils
    {
        public static string ObterTokenGwtCookie(HttpRequestBase Request)
        {
            if (Request == null)
            {
                throw new ArgumentException(nameof(Request));
            }

            var cookie = Request?.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                throw new InvalidOperationException("Cookie inexistente.");
            }

            return cookie.Value;

        }

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