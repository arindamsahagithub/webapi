using Sherlock.Apps.Repository.Contract; 
using System.Reflection;
namespace Sherlock.Apps.Repository.Implementation;

public abstract class Repository : IRepository
{
    private readonly GremlinHelper _gremlinHelper;
    public Repository(GremlinHelper gremlinHelper)
    {
        _gremlinHelper = gremlinHelper;
    }
    public async Task<int> AddNode(object value)
    {
        var res = 0;
        Type valueType = value.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(valueType.GetProperties());

        var insertQuery = "g.addV('" + valueType.Name + "')";        
        foreach(var prop in props)
        {   
            object propValue = prop.GetValue(value, null);
            if(propValue!=null) 
            {
                insertQuery += ".property('" + prop.Name + "', '" + propValue +"')";
            }            
        }

        if(insertQuery.Contains("property"))
        {
            insertQuery += ".property('pk', 'pk')";
        }
        
        var rs = await _gremlinHelper.SubmitRequest(insertQuery);
        
        if(rs!=null) res=1;

        return res;
    }
}