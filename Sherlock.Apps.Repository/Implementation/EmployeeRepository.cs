using Sherlock.Apps.Model;
using Sherlock.Apps.Repository.Contract;
using  Gremlin.Net.Driver;
namespace Sherlock.Apps.Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee, EmployeeEdges>, IEmployeeRepository
    {
        public EmployeeRepository(GremlinClient gremlinClient) : base(gremlinClient)
        {
        }
    }
}