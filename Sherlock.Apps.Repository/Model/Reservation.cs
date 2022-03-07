namespace Sherlock.Apps.Repository.Model
{
    public class Reservation : Base
    {
        public DateTime CheckInDate {get; set;}
        public DateTime CheckOutDate { get; set; }
    }
}