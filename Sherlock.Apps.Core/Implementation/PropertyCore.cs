using Sherlock.Apps.Core.Contract;
using Sherlock.Apps.Model;
namespace Sherlock.Apps.Core.Implementation;

public class PropertyCore : IPropertyCore
{
    private readonly IPropertyRepository _propertyRepository;
    public PropertyCore(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }
    public async Task<bool> AddProperty(Property property)
    {
        var res = false;
        res = await _propertyRepository.AddNode(property);
        return res;
    }
}