namespace ReadingRoom.Api.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for room details.
    /// </summary>
    public class RoomDTO
    {
        /// <summary>
        /// A unique identifier for the room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the room.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Capacity of the room.
        /// </summary>
        public int Capacity { get; set; }
    }
}
