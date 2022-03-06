

namespace Sherlock.Apps.Repository.Contract;

public interface IRepository<T>
{
    Task<int> AddNode(T value);
}