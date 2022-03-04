namespace sherlock.apps.repository.contract;

public interface IRepository
{
    Task<int> AddNode(object value);
}