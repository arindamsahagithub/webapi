using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sherlock.Apps.Model;

namespace Sherlock.Apps.Repository.Contract
{
    public interface IRepository<T,K>
    where T : class
    where K : Enum
    {
        Task<CDM> AddNodeAsync(T value);
        Task<CDM> UpdateNodeAsync(T value);
        Task<CDM> AddEdgeAsync(string outNodeId, string inNodeId, K edgeName);
        Task<IEnumerable<CDM>> GetAllAsync(Vertices type);
        Task<CDM> GetByIdAsync(string id);
    } 
}
