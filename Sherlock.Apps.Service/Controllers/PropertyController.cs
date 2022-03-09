using Microsoft.AspNetCore.Mvc;
using Sherlock.Apps.Core.Contract;

namespace Sherlock.Apps.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{  
    private readonly IPropertyCore _propertyCore;
    public PropertyController(IPropertyCore propertyCore)
    {
        _propertyCore = propertyCore;
    }

    [HttpGet(Name = "GetProperty")]
    public IEnumerable<Property> Get()
    {
        
    }

    [HttpPost(Name = "PostProperty")]
    public ActionResult Post(Property property)
    {
       _propertyCore.AddNode(property);
    }
}