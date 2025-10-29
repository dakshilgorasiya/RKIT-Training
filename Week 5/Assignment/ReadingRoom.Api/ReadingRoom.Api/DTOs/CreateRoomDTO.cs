using System.ComponentModel.DataAnnotations;

namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// A DTO for creating a new room.
    /// </summary>
    public class CreateRoomDTO
    {
        /// <summary>
        /// Name of the room.
        /// </summary>
        [Required(ErrorMessage = "Name of room is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Capacity of the room.
        /// </summary>

        [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100.")]
        public int Capacity { get; set; }
    }
}
