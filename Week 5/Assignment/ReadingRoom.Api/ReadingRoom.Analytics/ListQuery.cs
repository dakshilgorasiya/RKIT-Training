using Microsoft.EntityFrameworkCore;
using ReadingRoom.Data.Data;
using ReadingRoom.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRoom.Analytics
{
    /// <summary>
    /// A static class containing methods to perform LINQ queries on lists of rooms and reservations.
    /// </summary>
    public static class ListQuery
    {
        /// <summary>
        /// A method to demonstrate various LINQ queries on lists of rooms and reservations.
        /// </summary>
        /// <param name="dbContext">Database context for accessing rooms and reservations.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public static async Task Query(AppDbContext dbContext)
        {
            // Get all rooms and reservations from the database
            List<Room> rooms = await dbContext.Rooms.ToListAsync();
            List<Reservation> reservations = await dbContext.Reservations.ToListAsync();


            // Top N busiest room in a date range
            int n = 5;
            DateTime start = new DateTime(2025, 10, 14);
            DateTime end = new DateTime(2025, 10, 20);

            var topNBusiestRooms = reservations
                                        .Where(r => r.Status == ReservationStatus.Confirmed &&
                                                    r.Start < end &&
                                                    r.End > start)
                                        .GroupBy(r => r.RoomId)
                                        .Join(rooms,
                                              re => re.Key,
                                              r => r.Id,
                                              (re, r) => new
                                              {
                                                  RoomId = r.Id,
                                                  RoomName = r.Name,
                                              })
                                        .Select(r => new
                                        {
                                            RoomId = r.RoomId,
                                            RoomName = r.RoomName,
                                            TotalTime = reservations
                                                .Where(res => res.RoomId == r.RoomId)
                                                .Sum(res => (res.End - res.Start).TotalHours)
                                        })
                                        .OrderByDescending(result => result.TotalTime)
                                        .Take(n);

            foreach (var room in topNBusiestRooms)
            {
                Console.WriteLine(room);
            }

            // Conflicing reservations detection
            var conflictingReservations = from re1 in reservations
                                          join re2 in reservations on re1.RoomId equals re2.RoomId
                                          where re1.Id > re2.Id &&
                                                re1.Status == ReservationStatus.Confirmed &&
                                                re2.Status == ReservationStatus.Confirmed &&
                                                re1.Start < re2.End &&
                                                re2.Start < re1.End
                                          select new
                                          {
                                              ReservationId = re1.Id,
                                              conflictingReservations = re2.Id,
                                          };
            if (!conflictingReservations.Any())
            {
                Console.WriteLine("No conflicting reservations found.");

            }
            else
            {
                foreach (var conflict in conflictingReservations)
                {
                    Console.WriteLine(conflict);
                }
            }


            // Utilization rate per room
            DateTime startTime = new DateTime(2025, 10, 14);
            DateTime endTime = new DateTime(2025, 10, 20);

            var utilizationRates = rooms.Select(r => new
            {
                RoomId = r.Id,
                RoomName = r.Name,
                UtilizationRate = reservations
                    .Where(res => res.RoomId == r.Id &&
                                  res.Status == ReservationStatus.Confirmed &&
                                  res.Start < endTime &&
                                  res.End > startTime)
                    .Sum(res => ((double)(Math.Min(res.End.Ticks, endTime.Ticks) - Math.Max(res.Start.Ticks, startTime.Ticks))
                                    / (endTime.Ticks - startTime.Ticks) * 100)
                    )
            })
            .OrderByDescending(res => res.UtilizationRate);

            foreach (var utilization in utilizationRates)
            {
                Console.WriteLine(utilization);
            }
        }
    }
}
