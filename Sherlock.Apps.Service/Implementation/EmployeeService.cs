using System.Threading.Tasks;
using Sherlock.Apps.Model;
using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Service.Contract;

namespace Sherlock.Apps.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(Employee data)
        {            
            var res = false;
            await _unitOfWork.EmployeeRepository.AddNodeAsync(data);            
            return res;
        }

        public Task<bool> UpdateAsync(Employee data)
        {
            throw new System.NotImplementedException();
        }
    }
}