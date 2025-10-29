using System.Security.Cryptography;

namespace CryptographyPractise
{
    public class PasswordHasher
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 100000;

        public static string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            // Derive the hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combine salt and hash
            byte[] hashedBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashedBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashedBytes, SaltSize, HashSize);

            // Return as base64 string
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            // Extract the bytes
            byte[] hashedBytes = Convert.FromBase64String(storedHash);

            // Get the salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashedBytes, 0, salt, 0, SaltSize);

            // Get the hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compare the results
            // Use a time-constant comparison to prevent timing attacks
            return CryptographicOperations.FixedTimeEquals(hash, hashedBytes.AsSpan(SaltSize));
        }
    }
    internal class SecureHasingPractise
    {
        static void Main(string[] args)
        {
            string password = "MY_SECURE_PASSWORD";

            string hashedPassword = PasswordHasher.HashPassword(password);
            Console.WriteLine($"Hashed Password: {hashedPassword}");

            bool isVerified = PasswordHasher.VerifyPassword("password", hashedPassword);
            Console.WriteLine(isVerified ? "Verified" : "Not verfied");
        }
    }
}
