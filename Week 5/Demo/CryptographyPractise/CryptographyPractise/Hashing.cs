using System.Security.Cryptography;

namespace CryptographyPractise
{
    internal class Hashing
    {
        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

                return Convert.ToHexString(bytes);
            }
        }
        static void Main(string[] args)
        {
            string input = "Hello, World!";
            string hash = ComputeSHA256Hash(input);
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"SHA-256 Hash: {hash}");
        }
    }
}
