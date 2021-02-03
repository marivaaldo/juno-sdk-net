using PemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.DirectCheckouts
{
    public static class Crypto
    {
        public static string Encrypt(this Card card, string privateKey)
        {
            var json = JsonSerializer.Serialize(card, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return json.Encrypt(privateKey);
        }

        public static string Encrypt(this string text, string key)
        {
            var keyBytes = Convert.FromBase64String(key);

            var rsa = RSACng.Create();

            //var rsa = new RSACryptoServiceProvider();

            rsa.ImportSubjectPublicKeyInfo(keyBytes, out int _);

            var encryptedBytes = rsa.Encrypt(
                Encoding.UTF8.GetBytes(text),
                RSAEncryptionPadding.OaepSHA256);

            return Convert.ToBase64String(encryptedBytes);
        }
        private static X509Certificate2 GetCertificateFromBytes(byte[] cert)
        {
            string certFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            try
            {
                File.WriteAllBytes(certFile, cert);

                X509Store store = new X509Store(StoreLocation.CurrentUser);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certCollection = store.Certificates;
                    return certCollection[0];
                }
                finally
                {
                    store.Close();
                }
            }
            finally
            {
                File.Delete(certFile);
            }
        }



        //public static string ToPublicKey(this string str)
        //{
        //    var keyBytes = Convert.FromBase64String(str);
        //    var spec = new X509Certificate2(keyBytes);
        //    return spec.GetPublicKeyString();
        //}
    }
}


