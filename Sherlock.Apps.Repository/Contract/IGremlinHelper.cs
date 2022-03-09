using Gremlin.Net.Driver;

namespace Sherlock.Apps.Repository.Contract;

public interface IGremlinHelper
{
    Dictionary<string, string> GremlinQueries { get; }
    Task<int> SubmitRequest();
}