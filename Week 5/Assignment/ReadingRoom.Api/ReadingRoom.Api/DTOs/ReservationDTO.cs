using ReadingRoom.Data.Model;
using System.Text.Json.Serialization;

namespace ReadingRoom.Api.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string PatronName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReservationStatus Status { get; set; }
    }
}
