using System;
using System.Collections.Generic;
using System.Text;

namespace Sherlock.Apps.Func.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string GuestName { get; set; }
        public string ListingId { get; set; }
        public decimal Amount { get; set; }

    }
}
