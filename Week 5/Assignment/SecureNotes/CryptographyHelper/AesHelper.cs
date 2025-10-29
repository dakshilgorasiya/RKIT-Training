using System.Security.Cryptography;

namespace CryptographyHelper
{
    /// <summary>
    /// A helper class for AES encryption and decryption using AES-GCM.
    /// </summary>
    public static class AesHelper
    {
        /// <summary>
        /// A method to encrypt data using AES-GCM.
        /// </summary>
        /// <param name="data">Plain text to encrypt</param>
        /// <param name="key">Key to use while encrypting data</param>
        /// <returns>Cipher text encrypted using AES-GCM (iv + tag + cipher_text)</returns>
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            try
            {
                if (key == null || key.Length != 32)
                {
                    throw new ArgumentException("Key must be 32 bytes (256 bits) long.");
                }

                if(data == null || data.Length == 0)
                {
                    throw new ArgumentException("Data to encrypt cannot be null or empty.");
                }

                byte[] iv = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize); // random iv for each encryption
                byte[] cipherText = new byte[data.Length]; // to hold the encrypted data
                byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize]; // authentication tag

                AesGcm aesGcm = new(key);

                aesGcm.Encrypt(iv, data, cipherText, tag);

                byte[] forStorage = new byte[iv.Length + tag.Length + cipherText.Length]; // combined array to hold iv + tag + cipherText
                Array.Copy(iv, 0, forStorage, 0, iv.Length); // copy iv at the start
                Array.Copy(tag, 0, forStorage, iv.Length, tag.Length); // copy tag after iv
                Array.Copy(cipherText, 0, forStorage, iv.Length + tag.Length, cipherText.Length); // copy cipherText after tag

                return forStorage;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Argument error: " + ex.Message);
                return Array.Empty<byte>();
            }
            catch(CryptographicException ex)
            {
                Console.WriteLine("Cryptographic error: " + ex.Message);
                return Array.Empty<byte>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error during encryption: " + ex.Message);
                throw;
            }
            finally
            {
                Array.Clear(key, 0, key.Length); // Clear the key from memory
                Array.Clear(data, 0, data.Length); // Clear the plain text data from memory
            }
        }

        /// <summary>
        /// A method to decrypt data using AES-GCM.
        /// </summary>
        /// <param name="encryptedData">Encrypted data (iv + tag + ciphertext)</param>
        /// <param name="key">Key to use for aes decryption</param>
        /// <returns>Decrypted plain text</returns>
        public static byte[] Decrypt(byte[] encryptedData, byte[] key)
        {
            try
            {
                if (key == null || key.Length != 32)
                {
                    throw new ArgumentException("Key must be 32 bytes (256 bits) long.");
                }

                if (encryptedData == null || encryptedData.Length == 0)
                {
                    throw new ArgumentException("Data to encrypt cannot be null or empty.");
                }

                byte[] iv = new byte[AesGcm.NonceByteSizes.MaxSize];
                byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];
                byte[] cipherText = new byte[encryptedData.Length - iv.Length - tag.Length];

                Array.Copy(encryptedData, 0, iv, 0, iv.Length); // extract iv from the start
                Array.Copy(encryptedData, iv.Length, tag, 0, tag.Length); // extract tag after iv
                Array.Copy(encryptedData, iv.Length + tag.Length, cipherText, 0, cipherText.Length); // extract cipherText after tag

                byte[] decryptedBytes = new byte[cipherText.Length]; // to hold the decrypted data

                AesGcm aesGcm = new(key);
                aesGcm.Decrypt(iv, cipherText, tag, decryptedBytes);

                return decryptedBytes;
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
            finally
            {
                Array.Clear(key, 0, key.Length); // Clear the key from memory
            }
        }
    }
}
