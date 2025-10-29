using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using ReadingRoom.Api.Commons;
using ReadingRoom.Api.DTOs;
using ReadingRoom.Data.Data;
using ReadingRoom.Data.Model;

namespace ReadingRoom.Api.Endpoints
{
    /// <summary>
    /// A class containing endpoints related to reservations.
    /// </summary>
    public static class ReservationEndpoints
    {
        /// <summary>
        /// A method to create a new reservation.
        /// </summary>
        /// <param name="createReservationDTO">Data Transfer Object containing reservation details.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> CreateReservationAsync(CreateReservationDTO createReservationDTO, AppDbContext context)
        {
            // Validate the incoming DTO
            if (!MiniValidator.TryValidate(createReservationDTO, out IDictionary<string, string[]>? errors))
            {
                ApiResponse<IDictionary<string, string[]>> errorResponse = new ApiResponse<IDictionary<string, string[]>>
                {
                    StatusCode = 400,
                    Message = "Validation errors occurred.",
                    Data = errors
                };
                return Results.BadRequest(errorResponse);
            }

            // Check if the start time is before the end time
            if (createReservationDTO.StartTime >= createReservationDTO.EndTime)
            {
                ApiResponse<string> invalidTimeResponse = new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = "Start time must be before end time.",
                    Data = null
                };
                return Results.BadRequest(invalidTimeResponse);
            }

            // Check if the room exists
            Room? room = await context.Rooms.FindAsync(createReservationDTO.RoomId);
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

            // Create the reservation
            Reservation reservation = new Reservation
            {
                RoomId = createReservationDTO.RoomId,
                PatronName = createReservationDTO.PatronName,
                Start = createReservationDTO.StartTime,
                End = createReservationDTO.EndTime,
                Status = ReservationStatus.Pending,
            };

            context.Reservations.Add(reservation); // Add the reservation to the context

            await context.SaveChangesAsync(); // Save changes to the database

            // Check for overlapping reservations
            bool hasOverlap = await context.Reservations.AnyAsync(r =>
                r.RoomId == createReservationDTO.RoomId &&
                r.Status == ReservationStatus.Confirmed &&
                (createReservationDTO.StartTime < r.End && createReservationDTO.EndTime > r.Start)
            );

            if (hasOverlap)
            {
                reservation.Status = ReservationStatus.Cancelled; // Update reservation status to Cancelled

                context.Reservations.Update(reservation); // Update the reservation in the context

                await context.SaveChangesAsync(); // Save changes to the database

                ApiResponse<string> conflictResponse = new ApiResponse<string>
                {
                    StatusCode = 409,
                    Message = "The room is already booked for the selected time slot.",
                    Data = null
                };
                return Results.Conflict(conflictResponse);
            }


            reservation.Status = ReservationStatus.Confirmed; // Update reservation status to Confirmed

            context.Reservations.Update(reservation); // Update the reservation in the context

            await context.SaveChangesAsync(); // Save changes to the database

            // Prepare the response DTO
            ReservationDTO reservationDTOResponse = new ReservationDTO
            {
                Id = reservation.Id,
                RoomId = reservation.RoomId,
                PatronName = reservation.PatronName,
                Start = reservation.Start,
                End = reservation.End,
                Status = reservation.Status
            };

            // Prepare the API response
            ApiResponse<ReservationDTO> response = new ApiResponse<ReservationDTO>
            {
                StatusCode = 201,
                Message = "Reservation created successfully.",
                Data = reservationDTOResponse
            };

            // Return a Created result with the reservation details
            return Results.Created($"/reservations/{reservation.Id}", response);
        }

        /// <summary>
        /// A method to get reservations for a specific room within a given time range.
        /// </summary>
        /// <param name="roomId">ID of the room to get reservations for.</param>
        /// <param name="start">Start time of the range.</param>
        /// <param name="end">End time of the range.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> GetReservationsAsync([FromQuery] int roomId, [FromQuery] DateTime start, [FromQuery] DateTime end, AppDbContext context)
        {
            // Check if start time is before end time
            if (start >= end)
            {
                ApiResponse<string> invalidTimeResponse = new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = "Start time must be before end time.",
                    Data = null
                };
                return Results.BadRequest(invalidTimeResponse);
            }

            // Check if the room exists
            List<ReservationDTO> reservations = await context.Reservations
                .Where(r => r.RoomId == roomId && r.Start < end && r.End > start)
                .Select(r => new ReservationDTO
                {
                    Id = r.Id,
                    RoomId = r.RoomId,
                    PatronName = r.PatronName,
                    Start = r.Start,
                    End = r.End,
                    Status = r.Status
                })
                .ToListAsync();

            // Prepare the API response
            ApiResponse<List<ReservationDTO>> response = new ApiResponse<List<ReservationDTO>>
            {
                StatusCode = 200,
                Message = "Reservations retrieved successfully.",
                Data = reservations
            };

            // Return an OK result with the list of reservations
            return Results.Ok(response);
        }

        /// <summary>
        /// A method to update an existing reservation.
        /// </summary>
        /// <param name="updateReservationDTO">Data Transfer Object containing updated reservation details.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> UpdateReservationAsync(UpdateReservationDTO updateReservationDTO, AppDbContext context)
        {
            // Validate the incoming DTO
            if (!MiniValidator.TryValidate(updateReservationDTO, out IDictionary<string, string[]>? errors))
            {
                ApiResponse<IDictionary<string, string[]>> errorResponse = new ApiResponse<IDictionary<string, string[]>>
                {
                    StatusCode = 400,
                    Message = "Validation errors occurred.",
                    Data = errors
                };
                return Results.BadRequest(errorResponse);
            }

            // Check if the start time is before the end time
            if (updateReservationDTO.StartTime >= updateReservationDTO.EndTime)
            {
                ApiResponse<string> invalidTimeResponse = new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = "Start time must be before end time.",
                    Data = null
                };
                return Results.BadRequest(invalidTimeResponse);
            }

            // Check if the reservation exists
            Reservation? reservation = await context.Reservations.FindAsync(updateReservationDTO.Id);
            if (reservation == null)
            {
                ApiResponse<string> notFoundResponse = new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Reservation not found.",
                    Data = null
                };
                return Results.NotFound(notFoundResponse);
            }

            // Check if the room exists
            Room? room = await context.Rooms.FindAsync(updateReservationDTO.RoomId);
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

            bool hasOverlap = await context.Reservations.AnyAsync(r =>
                r.Id != updateReservationDTO.Id &&
                r.RoomId == updateReservationDTO.RoomId &&
                r.Status == ReservationStatus.Confirmed &&
                (updateReservationDTO.StartTime < r.End && updateReservationDTO.EndTime > r.Start)
            );

            if (hasOverlap)
            {
                ApiResponse<string> conflictResponse = new ApiResponse<string>
                {
                    StatusCode = 409,
                    Message = "The room is already booked for the selected time slot.",
                    Data = null
                };
                return Results.Conflict(conflictResponse);
            }

            // Update the reservation details
            reservation.RoomId = updateReservationDTO.RoomId;
            reservation.Start = updateReservationDTO.StartTime;
            reservation.End = updateReservationDTO.EndTime;

            context.Reservations.Update(reservation); // Update the reservation in the context
            await context.SaveChangesAsync(); // Save changes to the database

            // Prepare the response DTO
            ReservationDTO reservationDTOResponse = new ReservationDTO
            {
                Id = reservation.Id,
                RoomId = reservation.RoomId,
                PatronName = reservation.PatronName,
                Start = reservation.Start,
                End = reservation.End,
                Status = reservation.Status
            };

            // Prepare the API response
            ApiResponse<ReservationDTO> response = new ApiResponse<ReservationDTO>
            {
                StatusCode = 200,
                Message = "Reservation updated successfully.",
                Data = reservationDTOResponse
            };

            // Return an OK result with the reservation details
            return Results.Ok(response);
        }

        /// <summary>
        /// A method to delete an existing reservation.
        /// </summary>
        /// <param name="reservationId">Reservation ID to delete.</param>
        /// <param name="context">Database context for accessing the database.</param>
        /// <returns>IResult representing the outcome of the operation.</returns>
        public static async Task<IResult> DeleteReservationAsync(int reservationId, AppDbContext context)
        {
            // Check if the reservation exists
            Reservation? reservation = await context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                ApiResponse<string> notFoundResponse = new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Reservation not found.",
                    Data = null
                };
                return Results.NotFound(notFoundResponse);
            }

            // Delete the reservation
            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();

            // Prepare the API response
            ApiResponse<string> response = new ApiResponse<string>
            {
                StatusCode = 200,
                Message = "Reservation deleted successfully.",
                Data = null
            };

            // Return an OK result indicating successful deletion
            return Results.Ok(response);
        }
    }
}
