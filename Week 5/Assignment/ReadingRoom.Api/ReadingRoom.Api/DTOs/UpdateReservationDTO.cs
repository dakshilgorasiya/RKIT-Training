namespace ReadingRoom.Api.DTOs
{
    public class UpdateReservationDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
