using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Model;

namespace Sherlock.Apps.Repository.Implementation;
    public class GuestRepository : Repository<Property>, IGuestRepository
    {
        public GuestRepository(GremlinHelper gremlinHelper): base(gremlinHelper)
        {
            
        }
    }
