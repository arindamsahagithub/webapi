using Sherlock.Apps.Model;
using Sherlock.Apps.Repository.Contract;
using Sherlock.Apps.Service.Contract;
using System.Threading.Tasks;

namespace Sherlock.Apps.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(Property property)
        {
            var res = false;
            await _unitOfWork.PropertyRepository.AddNodeAsync(property);
            return res;
        }

        public async Task<bool> UpdateAsync(Property data)
        {
            var res = false;
            await _unitOfWork.PropertyRepository.UpdateNodeAsync(data);
            res = true;
            return res;
        }

        public async Task<bool> AssignEmployeeAsync(string propertyId, string employeeId)
        {
            var res = false;
            await _unitOfWork.PropertyRepository.AddEdgeAsync(propertyId, employeeId, PropertyEdges.have);
            res = true;
            return res;
        }
    }
}
