using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Repository.Model;

namespace Sherlock.Apps.Repository.Implementation
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(GremlinHelper gremlinHelper): base(gremlinHelper)
        {
            
        }
    }
}