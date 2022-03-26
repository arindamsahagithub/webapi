using System;
using System.Collections.Generic;
using System.Text;

namespace Sherlock.Apps.Func.Models
{
    public class Payout
    {
        public string AccountId { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
