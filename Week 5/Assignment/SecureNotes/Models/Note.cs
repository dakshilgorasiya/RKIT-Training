using Newtonsoft.Json;
using Operations;

namespace Models
{
    /// <summary>
    /// Represents a secure note.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// A unique identifier for the note.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Title of the note.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Encrypted body content of the note.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Time when the note was created.
        /// </summary>

        [JsonConverter(typeof(CustomDateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Time when the note was last updated.
        /// </summary>

        [JsonConverter(typeof(CustomDateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Salt used for encrypting the note body.
        /// </summary>
        public string? Salt { get; set; }
    }
}
