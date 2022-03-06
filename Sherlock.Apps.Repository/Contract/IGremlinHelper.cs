using Gremlin.Net.Driver;

namespace Sherlock.Apps.Repository.Contract;

public interface IGremlinHelper
{
    Task<ResultSet<dynamic>> SubmitRequest(string query);
}