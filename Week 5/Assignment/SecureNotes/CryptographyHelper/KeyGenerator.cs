using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyHelper
{
    /// <summary>
    /// A class to generate encryption keys using PBKDF2 from a given password and salt.
    /// </summary>
    public class KeyGenerator
    {
        /// <summary>
        /// Size of the key to generate in bytes (32 bytes = 256 bits).
        /// </summary>
        private readonly int _keySize = 32; // 256 bits

        /// <summary>
        /// Number of iterations for the PBKDF2 algorithm.
        /// </summary>
        private readonly int _iterations = 100000;

        /// <summary>
        /// Key or password used for key generation.
        /// </summary>
        private readonly string _key;

        /// <summary>
        /// A constructor to initialize the KeyGenerator with a specific key or password.
        /// </summary>
        /// <param name="key"></param>
        public KeyGenerator(string key)
        {
            _key = key;
        }

        /// <summary>
        /// A method to generate a cryptographic key using PBKDF2 with the provided salt.
        /// </summary>
        /// <param name="salt">Salt to use while creating hast</param>
        /// <returns>Hashed key with added salt for randomization</returns>
        public byte[] GenerateKey(byte[] salt)
        {
            try
            {
                if (salt == null || salt.Length != 16)
                {
                    throw new ArgumentException("Salt must be 16 bytes (128 bits) long.");
                }

                // Using PBKDF2 with SHA256 to derive a key from the password and salt
                var pbkdf2 = new Rfc2898DeriveBytes(_key, salt, _iterations, HashAlgorithmName.SHA256);
                return pbkdf2.GetBytes(_keySize);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument error: " + ex.Message);
                return Array.Empty<byte>();
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Cryptographic error: " + ex.Message);
                return Array.Empty<byte>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error during encryption: " + ex.Message);
                throw;
            }
        }
    }
}
