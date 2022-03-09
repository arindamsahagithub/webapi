using Sherlock.Apps.Repository.;
using Sherlock.Apps.Model;

namespace Sherlock.Apps.Repository.Implementation;
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(GremlinHelper gremlinHelper): base(gremlinHelper)
        {
            
        }
    }
