using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Operations;

namespace Models
{
    /// <summary>
    /// Represents the metadata or header information for a note.
    /// </summary>
    /// <remarks>Used for storing all notes metadata without storing body for optimization</remarks>
    public class NoteHeader
    {
        /// <summary>
        /// Unique identifier for the note.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Title of note.
        /// </summary>
        public string? Title { get; set; }

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
    }
}
