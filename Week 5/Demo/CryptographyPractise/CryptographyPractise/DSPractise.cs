using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace CryptographyPractise
{
    internal class DSPractise
    {
        static void Main(string[] args)
        {
            string original = "Hello, World!";

            using(RSA rsa = RSA.Create(2048))
            {
                byte[] data = Encoding.UTF8.GetBytes(original);
                byte[] sign = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                Console.WriteLine($"Sign: {Convert.ToBase64String(sign)}");

                bool isVerified = rsa.VerifyData(data, sign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Console.WriteLine($"Signature verification status : {isVerified}");
            }



            // Accessing secret key from The Secret Manager
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<DSPractise>();
            var configuration = builder.Build();
            Console.WriteLine($"Secret Key: {configuration["APIKEY"]}");

        }
    }
}
