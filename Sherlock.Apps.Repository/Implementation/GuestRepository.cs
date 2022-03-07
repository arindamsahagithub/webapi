using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Repository.Model;

namespace Sherlock.Apps.Repository.Implementation
{
    public class GuestRepository : Repository<Guest> , IGuestRepository
    {
        public GuestRepository(GremlinHelper gremlinHelper): base(gremlinHelper)
        {
            
        }
    }
}