using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingRoom.Data.Model
{
    /// <summary>
    /// An enumeration representing the status of a reservation.
    /// </summary>
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
