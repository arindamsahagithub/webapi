using System.Threading.Tasks;

namespace Sherlock.Apps.Service.Contract
{
    public interface IService<T> where T : class
    {
         Task<bool> AddAsync(T data);
         Task<bool> UpdateAsync(T data);
    }
}