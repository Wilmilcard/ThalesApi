using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ThalesApi.Domain
{
    public class Encrypt
    {
        //Encrypt
        public static string MD5(string password)
        {
            string serializar, rpta;

            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();

            serializar = serialize(encoded);
            rpta = encoded.Substring(0, 16) + serializar;

            return rpta;
        }

        private static string serialize(string cadena)
        {
            string rpta;

            byte[] encodedPassword = new UTF8Encoding().GetBytes(cadena);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
            rpta = encoded.Substring(0, 16);
            return rpta;

        }
        //
    }
}
