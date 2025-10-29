using System.ComponentModel.DataAnnotations;

namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// A DTO for updating an existing room.
    /// </summary>
    public class UpdateRoomDTO
    {
        /// <summary>
        /// A unique identifier for the room.
        /// </summary>
        [Required(ErrorMessage ="Room is required")]
        public int Id { get; set; }

        /// <summary>
        /// Updated name of the room.
        /// </summary>
        [Required(ErrorMessage ="Room name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Updated capacity of the room.
        /// </summary>
        [Required(ErrorMessage ="Room capacity is required")]
        [Range(1, 100, ErrorMessage ="Capacity must be between 1 and 100")]
        public int Capacity { get; set; }
    }
}
