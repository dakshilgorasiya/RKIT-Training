namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for updating an existing reservation.
    /// </summary>
    public class UpdateReservationDTO
    {
        /// <summary>
        /// Identifier of the reservation to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Updated room identifier for the reservation.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Updated start time of the reservation.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Updated end time of the reservation.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
