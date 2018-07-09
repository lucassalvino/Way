using System;
using System.Security.Cryptography;
using System.Text;

namespace Way.Domain
{
    public class Util
    {
        public static String HashSHA256(String value)
        {
            using (SHA256 objSha = SHA256.Create())
            {
                byte[] bytes = objSha.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder Retorno = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    Retorno.Append(bytes[i].ToString("x2"));
                return Retorno.ToString().ToUpper();
            }
        }
    }
}
