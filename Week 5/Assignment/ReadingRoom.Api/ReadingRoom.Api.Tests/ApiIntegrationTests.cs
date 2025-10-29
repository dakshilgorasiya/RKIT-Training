using FluentAssertions;
using ReadingRoom.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ReadingRoom.Data.Model;
using Microsoft.Extensions.DependencyInjection;
using ReadingRoom.Data.Data;
using ReadingRoom.Api.Commons;

namespace ReadingRoom.Api.Tests
{
    public class ApiIntegrationTests: IClassFixture<CustomApiFactory>
    {
        private readonly HttpClient _client;
        private readonly CustomApiFactory _factory;

        public ApiIntegrationTests(CustomApiFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task POST_CreateRoom_ShouldReturnCreated_WhenDtoIsValid()
        {
            // Arrange
            var newRoomDto = new CreateRoomDTO
            {
                Name = "Test Room",
                Capacity = 5
            };

            // Act
            var response = await _client.PostAsJsonAsync("/rooms", newRoomDto);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<RoomDTO>>();

            var room = apiResponse.Data;

            room.Should().NotBeNull();

            room.Name.Should().Be("Test Room");

            room.Capacity.Should().Be(5);
        }

        [Fact]
        public async Task PUT_Room_ShouldReturnOk_WhenDtoIsValid()
        {
            // Arrange
            var updateRoomDto = new UpdateRoomDTO
            {
                Id = 1,
                Name = "Updated name",
                Capacity = 10
            };

            // Act
            var response = await _client.PutAsJsonAsync("/rooms", updateRoomDto);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<RoomDTO>>();

            var room = apiResponse.Data;

            room.Should().NotBeNull();

            room.Name.Should().Be("Updated name");

            room.Capacity.Should().Be(10);
        }

        [Fact]
        public async Task POST_Reservation_ShouldReturnConflict()
        {
            // Arrange
            var firstReservation = new CreateReservationDTO
            {
                RoomId = 3,
                PatronName = "Test",
                StartTime = new DateTime(2025, 11, 1),
                EndTime = new DateTime(2025, 11, 5)
            };

            var secondReservation = new CreateReservationDTO
            {
                RoomId = 3,
                PatronName = "Test",
                StartTime = new DateTime(2025, 11, 3),
                EndTime = new DateTime(2025, 11, 6)
            };

            // Act
            var res1 = await _client.PostAsJsonAsync("/reservations", firstReservation);

            var res2 = await _client.PostAsJsonAsync("/reservations", secondReservation);

            // Assert
            res1.StatusCode.Should().Be(HttpStatusCode.Created);

            res2.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}
