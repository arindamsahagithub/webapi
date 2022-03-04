namespace sherlock.apps.repository.contract;

public interface GremlinHelper
{
    Task<int> AddNode(object value);
}