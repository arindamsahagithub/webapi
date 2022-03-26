using System;

namespace Sherlock.Apps.Func.Models
{
    public class NewReservation
    {
        public string ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string GuestName { get; set; }
        public string ListingId { get; set; }
        public int GuestCount { get; set; }

    }
}