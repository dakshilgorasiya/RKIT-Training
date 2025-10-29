namespace ReadingRoom.Api.DTOs
{
    public class CreateReservationDTO
    {
        public int RoomId { get; set; }
        public string PatronName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
