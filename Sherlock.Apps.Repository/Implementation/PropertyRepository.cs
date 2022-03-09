using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Model;
namespace Sherlock.Apps.Repository.Implementation;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(GremlinHelper gremlinHelper): base(gremlinHelper)
    {
        
    }
}