using Models;
using CryptographyHelper;
using IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Operations
{
    /// <summary>
    /// A helper class to perform CRUD operations on secure notes.
    /// </summary>
    public class OperationHelper
    {
        /// <summary>
        /// instance of KeyGenerator to handle key generation for encryption and decryption.
        /// </summary>
        private readonly KeyGenerator _keyGenerator;

        /// <summary>
        /// Constructor to initialize the OperationHelper with a KeyGenerator instance.
        /// </summary>
        public OperationHelper()
        {
            // TODO: Store secret key to secret valut and retrive from it.
            _keyGenerator = new KeyGenerator("SecreteKey");
        }

        /// <summary>
        /// A method to read and decrypt a note by its unique identifier.
        /// </summary>
        /// <param name="id">Id of the note to read</param>
        /// <returns>Object of Note or null if note is not found or decryption fails</returns>
        public Note? ReadNote(Guid id)
        {
            try
            {
                string filePath = Path.Combine("Vault", id.ToString() + ".json");

                string? json = IOHelper.ReadFile(filePath);

                if(string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("Error: File is empty");
                    return null;
                }

                Note? note = JsonConvert.DeserializeObject<Note>(json);

                if(note == null)
                {
                    Console.WriteLine("Error: Unable to deserialize note");
                    return null;
                }

                byte[] salt = Convert.FromBase64String(note.Salt); // Decode the base64 salt
                byte[] key = _keyGenerator.GenerateKey(salt); // Generate key using the salt

                byte[] encryptedBody = Convert.FromBase64String(note.Body); // Decode the base64 encrypted body
                byte[] decryptedBody = AesHelper.Decrypt(encryptedBody, key); // Decrypt the body using the generated key

                if (decryptedBody == null || decryptedBody.Length == 0)
                {
                    Console.WriteLine("Error: Unable to decrypt note body");
                    return null;
                }

                note.Body = System.Text.Encoding.UTF8.GetString(decryptedBody); // Convert decrypted bytes back to string

                return note;
            }
            catch(JsonException ex)
            {
                Console.WriteLine("JSON error: " + ex.Message);
                return null;
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to create and encrypt a new note with the given title and body.
        /// </summary>
        /// <param name="title">Title of the note</param>
        /// <param name="body">Body of the note</param>
        public void CreateNote(string title, string body)
        {
            try
            {
                byte[] salt = RandomNumberGenerator.GetBytes(16); // Generate a random 16-byte salt

                byte[] key = _keyGenerator.GenerateKey(salt); // Generate key using the salt

                byte[] encryptedBody = AesHelper.Encrypt(System.Text.Encoding.UTF8.GetBytes(body), key); // Encrypt the body using the generated key
                body = Convert.ToBase64String(encryptedBody); // Convert encrypted bytes to base64 string for storage

                Note note = new Note
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Body = body,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Salt = Convert.ToBase64String(salt)
                };

                string json = JsonConvert.SerializeObject(note, Formatting.Indented); // Serialize the note object to JSON

                string filePath = Path.Combine("Vault", note.Id.ToString() + ".json"); // Define the file path to store the note
                 
                IOHelper.WriteFile(filePath, json); // Write the JSON content to the file
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to update an existing note's title and body by its unique identifier.
        /// </summary>
        /// <param name="id">Unique id of the note</param>
        /// <param name="title">Title of the note</param>
        /// <param name="body">Body of the note</param>
        public void UpdateNote(Guid id, string title, string body)
        {
            try
            {
                Note? note = ReadNote(id); // Read the existing note

                byte[] salt = Convert.FromBase64String(note.Salt); // Decode the base64 salt
                byte[] key = _keyGenerator.GenerateKey(salt); // Generate key using the salt

                byte[] encryptedBody = AesHelper.Encrypt(System.Text.Encoding.UTF8.GetBytes(body), key); // Encrypt the new body using the generated key
                body = Convert.ToBase64String(encryptedBody); // Convert encrypted bytes to base64 string for storage

                note.Title = title;

                note.Body = body;

                note.UpdatedAt = DateTime.Now;

                string json = JsonConvert.SerializeObject(note, Formatting.Indented); // Serialize the updated note object to JSON

                string filePath = Path.Combine("Vault", note.Id.ToString() + ".json"); // Define the file path to store the note

                IOHelper.WriteFile(filePath, json); // Write the JSON content to the file
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to delete a note by its unique identifier.
        /// </summary>
        /// <param name="id">Unique id of note to delete</param>
        public void DeleteNote(Guid id)
        {
            string filePath = Path.Combine("Vault", id.ToString() + ".json"); // Define the file path of the note to delete
            IOHelper.DeleteFile(filePath); // Delete the file
        }

        /// <summary>
        /// A method to list all note's headers (metadata) without decrypting their bodies.
        /// </summary>
        /// <returns>List of NoteHeader objects</returns>
        public List<NoteHeader> ListNotes()
        {
            List<FileInfo> files = IOHelper.getAllFileMetadata().ToList(); // Get metadata of all files in the "Vault" directory

            List<NoteHeader> noteHeaders = new List<NoteHeader>(); // To hold headers of all files

            foreach (FileInfo file in files)
            {
                string content = IOHelper.ReadFile(file.FullName);

                NoteHeader header = JsonConvert.DeserializeObject<NoteHeader>(content);

                noteHeaders.Add(header);
            }

            return noteHeaders;
        }
    }
}
