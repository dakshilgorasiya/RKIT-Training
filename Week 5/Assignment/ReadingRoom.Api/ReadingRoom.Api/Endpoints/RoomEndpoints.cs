using ReadingRoom.Api.DTOs;
using ReadingRoom.Data.Data;
using ReadingRoom.Data.Model;
using ReadingRoom.Api.Commons;
using MiniValidation;
using Microsoft.EntityFrameworkCore;

namespace ReadingRoom.Api.Endpoints
{
    /// <summary>
    /// A static class containing endpoints related to room management.
    /// </summary>
    public static class RoomEndpoints
    {
        /// <summary>
        /// A method to create a new room.
        /// </summary>
        /// <param name="createRoomDTO">Data Transfer Object containing room details.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> CreateRoomAsync(CreateRoomDTO createRoomDTO, AppDbContext context)
        {
            // Validate the incoming DTO
            if (!MiniValidator.TryValidate(createRoomDTO, out IDictionary<string, string[]>? errors))
            {
                ApiResponse<IDictionary<string, string[]>> errorResponse = new ApiResponse<IDictionary<string, string[]>>
                {
                    StatusCode = 400,
                    Message = "Validation errors occurred.",
                    Data = errors
                };
                return Results.BadRequest(errorResponse);
            }

            // Create a new Room entity
            Room room = new Room
            {
                Name = createRoomDTO.Name,
                Capacity = createRoomDTO.Capacity
            };

            await context.Rooms.AddAsync(room); // Add the new room to the database context

            await context.SaveChangesAsync(); // Save changes to the database

            // Prepare the response DTO
            RoomDTO createRoomDTOResponse = new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity
            };

            // Prepare the API response
            ApiResponse<RoomDTO> response = new ApiResponse<RoomDTO>
            {
                StatusCode = 201,
                Message = "Room created successfully.",
                Data = createRoomDTOResponse
            };

            // Return a Created result with the location of the new resource
            return Results.Created($"/rooms/{room.Id}", response);
        }


        /// <summary>
        /// A method to retrieve all rooms.
        /// </summary>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> GetAllRoomsAsync(AppDbContext context)
        {
            List<Room> rooms = await context.Rooms.ToListAsync(); // Retrieve all rooms from the database

            // Map Room entities to RoomDTOs
            List<RoomDTO> roomDTOs = rooms.Select(r => new RoomDTO
            {
                Id = r.Id,
                Name = r.Name,
                Capacity = r.Capacity
            }).ToList();

            // Prepare the API response
            ApiResponse<List<RoomDTO>> response = new ApiResponse<List<RoomDTO>>
            {
                StatusCode = 200,
                Message = "Rooms retrieved successfully.",
                Data = roomDTOs
            };

            // Return an OK result with the list of rooms
            return Results.Ok(response);
        }

        /// <summary>
        /// A method to update an existing room.
        /// </summary>
        /// <param name="updateRoomDTO">Data Transfer Object containing updated room details.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> UpdateRoomAsync(UpdateRoomDTO updateRoomDTO, AppDbContext context)
        {
            // Validate the incoming DTO
            if (!MiniValidator.TryValidate(updateRoomDTO, out IDictionary<string, string[]>? errors))
            {
                ApiResponse<IDictionary<string, string[]>> errorResponse = new ApiResponse<IDictionary<string, string[]>>
                {
                    StatusCode = 400,
                    Message = "Validation errors occurred.",
                    Data = errors
                };
                return Results.BadRequest(errorResponse);
            }

            // Find the existing room by ID
            Room? room = await context.Rooms.FindAsync(updateRoomDTO.Id);
            if (room == null)
            {
                ApiResponse<string> notFoundResponse = new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Room not found.",
                    Data = null
                };
                return Results.NotFound(notFoundResponse);
            }

            // Update the room properties
            room.Name = updateRoomDTO.Name;
            room.Capacity = updateRoomDTO.Capacity;

            context.Rooms.Update(room); // Update the room in the database context
            await context.SaveChangesAsync(); // Save changes to the database

            // Prepare the response DTO
            RoomDTO updatedRoomDTOResponse = new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity
            };

            // Prepare the API response
            ApiResponse<RoomDTO> response = new ApiResponse<RoomDTO>
            {
                StatusCode = 200,
                Message = "Room updated successfully.",
                Data = updatedRoomDTOResponse
            };

            // Return an OK result with the updated room details
            return Results.Ok(response);
        }

        /// <summary>
        /// A method to delete an existing room.
        /// </summary>
        /// <param name="id">ID of the room to be deleted.</param>
        /// <param name="context">A database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> DeleteRoomAsync(int id, AppDbContext context)
        {
            // Find the existing room by ID
            Room? room = await context.Rooms.FindAsync(id);

            // If the room does not exist, return a NotFound response
            if (room == null)
            {
                ApiResponse<string> notFoundResponse = new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Room not found.",
                    Data = null
                };
                return Results.NotFound(notFoundResponse);
            }

            context.Rooms.Remove(room); // Remove the room from the database context
            await context.SaveChangesAsync(); // Save changes to the database

            // Prepare the API response
            ApiResponse<string> response = new ApiResponse<string>
            {
                StatusCode = 200,
                Message = "Room deleted successfully.",
                Data = null
            };

            // Return an OK result indicating successful deletion
            return Results.Ok(response);
        }
    }
}
