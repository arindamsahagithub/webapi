using Sherlock.Apps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock.Apps.Service.Contract
{
    public interface IPropertyService : IService<Property>
    {
        Task<bool> AssignEmployeeAsync(string propertyId, string employeeId);
    }
}
