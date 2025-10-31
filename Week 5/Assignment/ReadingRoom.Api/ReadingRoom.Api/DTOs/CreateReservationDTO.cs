using System.ComponentModel.DataAnnotations;

namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// A DTO for creating a new reservation.
    /// </summary>
    public class CreateReservationDTO
    {
        /// <summary>
        /// A unique identifier for the room to be reserved.
        /// </summary>
        [Required(ErrorMessage ="RoomId is required.")]
        public int RoomId { get; set; }

        /// <summary>
        /// Name of the patron making the reservation.
        /// </summary>
        [Required(ErrorMessage = "PatronName is required.")]
        public string PatronName { get; set; }

        /// <summary>
        /// Start time of the reservation.
        /// </summary>

        [Required(ErrorMessage = "StartTime is required.")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of the reservation.
        /// </summary>

        [Required(ErrorMessage = "EndTime is required.")]
        public DateTime EndTime { get; set; }
    }
}
