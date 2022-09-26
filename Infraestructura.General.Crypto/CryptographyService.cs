using System;
using System.Security.Cryptography;
using System.Text;

namespace Infraestructura.General.Crypto
{
    public class CryptographyService : ICryptographyService
    {
        private const string error_ValueEmpty = "Existen valores vacios dentro del servicio de criptografia";

        public string Encriptar(string llaveSecreta, string valorRaw)
        {
            if (string.IsNullOrEmpty(llaveSecreta))
                throw new ArgumentException(nameof(llaveSecreta), error_ValueEmpty);
            if (string.IsNullOrEmpty(valorRaw))
                throw new ArgumentException(nameof(valorRaw), error_ValueEmpty);
            //valor codificado del texto a encriptar
            var toCyp = Encoding.UTF8.GetBytes(valorRaw);
            //crea un has para el valor provisto usando el algoritmo de hash md5
            MD5CryptoServiceProvider Hashmd5 = new MD5CryptoServiceProvider();
            var hashkey = Hashmd5.ComputeHash(Encoding.UTF8.GetBytes(llaveSecreta));
            Hashmd5.Clear();

            //algoritmo de encriptacion simetrica tripleDES
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = hashkey;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //paso encriptar

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            var cypher = cTransform.TransformFinalBlock(toCyp, 0, toCyp.Length);
            tdes.Clear();

            return Convert.ToBase64String(cypher, 0, cypher.Length);

        }

        public string Desencriptar(string llaveSecreta, string encrypted)
        {
            if (string.IsNullOrEmpty(llaveSecreta))
                throw new ArgumentException(nameof(llaveSecreta), error_ValueEmpty);
            if (string.IsNullOrEmpty(encrypted))
                throw new ArgumentException(nameof(encrypted), error_ValueEmpty);
            //convertir a bytes el valor encriptado
            var decryp = Convert.FromBase64String(encrypted);

            //crea un has para el valor provisto usando el algoritmo de hash md5
            MD5CryptoServiceProvider Hashmd5 = new MD5CryptoServiceProvider();
            var hashkey = Hashmd5.ComputeHash(Encoding.UTF8.GetBytes(llaveSecreta));
            Hashmd5.Clear();

            //algoritmo de encriptacion simetrica tripleDES
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = hashkey;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            //paso desencriptar

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            var decifr = cTransform.TransformFinalBlock(decryp, 0, decryp.Length);
            tdes.Clear();

            return Convert.ToBase64String(decifr, 0, decifr.Length);


        }
    }
}
