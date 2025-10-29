using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyPractise
{
    internal class RSAPractise
    {
        static void Main(string[] args)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                RSAParameters publicKey = rsa.ExportParameters(false);
                RSAParameters privateKey = rsa.ExportParameters(true);


                string original = "Hello, World!";
                Console.WriteLine("Original: " + original);


                byte[] encrypted = RsaEncrypt(original, publicKey);
                Console.WriteLine("Encrypted: " + Convert.ToHexString(encrypted));


                byte[] decrypted = RsaDecrypt(encrypted, privateKey);
                Console.WriteLine("Decrypted: " + Encoding.UTF8.GetString(decrypted));
            }
        }

        static byte[] RsaEncrypt(string plainText, RSAParameters publicKey)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                return rsa.Encrypt(bytes, false);
            }
        }

        static byte[] RsaDecrypt(byte[] cipherText, RSAParameters privateKey)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(cipherText, false);
            }
        }
    }
}
