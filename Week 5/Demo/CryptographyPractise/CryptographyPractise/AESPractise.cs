using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyPractise
{
    internal class AESPractise
    {
        static void Main(string[] args)
        {
            byte[] key = RandomNumberGenerator.GetBytes(32); // 256 bit key

            using var aesGcm = new AesGcm(key);

            string original = "Hello, World!";
            Console.WriteLine(original);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(original);


            // Encryption
            byte[] nonce = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize);
            byte[] cipherText = new byte[plainTextBytes.Length];
            byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize]; // Authentication tag

            aesGcm.Encrypt(nonce, plainTextBytes, cipherText, tag);

            byte[] forStorage = new byte[nonce.Length + tag.Length + cipherText.Length];
            Array.Copy(nonce, 0, forStorage, 0, nonce.Length);
            Array.Copy(tag, 0, forStorage, nonce.Length, tag.Length);
            Array.Copy(cipherText, 0, forStorage, nonce.Length + tag.Length, cipherText.Length);
            Console.WriteLine($"Combined (Nonce + Tag + CipherText) : {Convert.ToBase64String(forStorage)}");

            Console.WriteLine($"Nonce : {Convert.ToBase64String(nonce)}");
            Console.WriteLine($"Cipher Text : {Convert.ToBase64String(cipherText)}");
            Console.WriteLine($"Tag : {Convert.ToBase64String(tag)}");


            // Decryption
            byte[] extractedNonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            byte[] extractedTag = new byte[AesGcm.TagByteSizes.MaxSize];
            byte[] extractedCipherText = new byte[forStorage.Length - extractedNonce.Length - extractedTag.Length];
            Array.Copy(forStorage, 0, extractedNonce, 0, extractedNonce.Length);
            Array.Copy(forStorage, extractedNonce.Length, extractedTag, 0, extractedTag.Length);
            Array.Copy(forStorage, extractedNonce.Length + extractedTag.Length, extractedCipherText, 0, extractedCipherText.Length);
            byte[] decryptedBytes = new byte[extractedCipherText.Length];

            aesGcm.Decrypt(extractedNonce, extractedCipherText, extractedTag, decryptedBytes);

            string decrypted = Encoding.UTF8.GetString(decryptedBytes);
            Console.WriteLine($"Decrypted : {decrypted}");
            Console.WriteLine($"Decryption {(original == decrypted ? "Succeeded" : "Failed")}");

        }
    }
}
