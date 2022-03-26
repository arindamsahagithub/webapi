using Sherlock.Apps.Model;
using Sherlock.Apps.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gremlin.Net.Driver;
namespace Sherlock.Apps.Repository.Implementation
{
    public class GuestRepository : Repository<Guest,GuestEdges>, IGuestRepository
    {
        public GuestRepository(GremlinClient gremlinClient) : base(gremlinClient)
        {

        }
    }
}
