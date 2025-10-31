using ReadingRoom.Data.Model;
using System.Text.Json.Serialization;

namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for reservation details.
    /// </summary>
    public class ReservationDTO
    {
        /// <summary>
        /// Unique identifier for the reservation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique identifier for the room associated with the reservation.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Name of the patron who made the reservation.
        /// </summary>
        public string PatronName { get; set; }

        /// <summary>
        /// Start time of the reservation.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End time of the reservation.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Status of the reservation.
        /// </summary>

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReservationStatus Status { get; set; }
    }
}
