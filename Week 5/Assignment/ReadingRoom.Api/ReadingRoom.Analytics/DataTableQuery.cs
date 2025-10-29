using Microsoft.EntityFrameworkCore;
using ReadingRoom.Data.Data;
using ReadingRoom.Data.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRoom.Analytics
{
    /// <summary>
    /// A static class containing methods to perform LINQ queries on DataTables of rooms and reservations.
    /// </summary>
    public static class DataTableQuery
    {
        /// <summary>
        /// A method to demonstrate various LINQ queries on DataTables of rooms and reservations.
        /// </summary>
        /// <param name="dbContext">Database context for accessing rooms and reservations.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public static async Task Query(AppDbContext dbContext)
        {
            // Get all rooms and reservations from the database
            List<Room> rooms = await dbContext.Rooms.ToListAsync();
            List<Reservation> reservations = await dbContext.Reservations.ToListAsync();

            // Convert lists to DataTables
            DataTable roomTable = DataTableQuery.ToDataTable(rooms);
            DataTable reservationTable = DataTableQuery.ToDataTable(reservations);

            // Top N busiest room in a date range - DataTable
            int n = 5;
            DateTime start = new DateTime(2025, 10, 14);
            DateTime end = new DateTime(2025, 10, 20);
            var topNBusiestRoomsTable = from re in reservationTable.AsEnumerable()
                                        where re.Field<ReservationStatus>("Status") == ReservationStatus.Confirmed &&
                                              re.Field<DateTime>("Start") < end &&
                                              re.Field<DateTime>("End") > start
                                        group re by re.Field<int>("RoomId") into g
                                        join r in roomTable.AsEnumerable() on g.Key equals r.Field<int>("Id")
                                        select new
                                        {
                                            RoomId = r.Field<int>("Id"),
                                            RoomName = r.Field<string>("Name"),
                                            TotalTime = g.Sum(res => (res.Field<DateTime>("End") - res.Field<DateTime>("Start")).TotalHours)
                                        } into result
                                        orderby result.TotalTime descending
                                        select result;

            foreach (var room in topNBusiestRoomsTable)
            {
                Console.WriteLine(room);
            }


            // Conflicing reservations detection - DataTable
            var conflictingReservationsTable = from re1 in reservationTable.AsEnumerable()
                                               join re2 in reservationTable.AsEnumerable() on re1.Field<int>("RoomId") equals re2.Field<int>("RoomId")
                                               where re1.Field<int>("Id") > re2.Field<int>("Id") &&
                                                     re1.Field<ReservationStatus>("Status") == ReservationStatus.Confirmed &&
                                                     re2.Field<ReservationStatus>("Status") == ReservationStatus.Confirmed &&
                                                     re1.Field<DateTime>("Start") < re2.Field<DateTime>("End") &&
                                                     re2.Field<DateTime>("Start") < re1.Field<DateTime>("End")
                                               select new
                                               {
                                                   ReservationId = re1.Field<int>("Id"),
                                                   conflictingReservations = re2.Field<int>("Id"),
                                               };

            if (!conflictingReservationsTable.Any())
            {
                Console.WriteLine("No conflicting reservations found.");
            }
            else
            {
                foreach (var conflict in conflictingReservationsTable)
                {
                    Console.WriteLine(conflict);
                }
            }


            // Utilization rate per room - DataTable
            DateTime startTime = new DateTime(2025, 10, 14);
            DateTime endTime = new DateTime(2025, 10, 20);
            var utilizationRatesTable = from r in roomTable.AsEnumerable()
                                        select new
                                        {
                                            RoomId = r.Field<int>("Id"),
                                            RoomName = r.Field<string>("Name"),
                                            UtilizationRate = (from res in reservationTable.AsEnumerable()
                                                               where res.Field<int>("RoomId") == r.Field<int>("Id") &&
                                                                     res.Field<ReservationStatus>("Status") == ReservationStatus.Confirmed &&
                                                                     res.Field<DateTime>("Start") < endTime &&
                                                                     res.Field<DateTime>("End") > startTime
                                                               select ((double)(Math.Min(res.Field<DateTime>("End").Ticks, endTime.Ticks) - Math.Max(res.Field<DateTime>("Start").Ticks, startTime.Ticks))
                                                                        / (endTime.Ticks - startTime.Ticks) * 100)
                                                              ).Sum()
                                        } into res
                                        orderby res.UtilizationRate descending
                                        select res;

            foreach (var utilization in utilizationRatesTable)
            {
                Console.WriteLine(utilization);
            }
        }

        /// <summary>
        /// A method to convert a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T">Type of objects in the list.</typeparam>
        /// <param name="items">List of objects to convert.</param>
        /// <returns>DataTable representing the list of objects.</returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            Type type = typeof(T);

            // Create DataTable
            DataTable dt = new DataTable(type.Name);


            // Create columns
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                Type columnType = propertyInfo.PropertyType;
                dt.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(columnType) ?? columnType);
            }

            // Copy data
            foreach (T item in items)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    row[propertyInfo.Name] = propertyInfo.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
