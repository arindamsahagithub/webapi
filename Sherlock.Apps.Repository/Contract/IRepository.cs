

namespace Sherlock.Apps.Repository.Contract;

public interface IRepository
{
    Task<int> AddNode(object value);
}