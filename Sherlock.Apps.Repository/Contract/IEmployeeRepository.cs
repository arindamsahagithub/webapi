using Sherlock.Apps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock.Apps.Repository.Contract
{
    public interface IEmployeeRepository : IRepository<Employee , EmployeeEdges>
    {
    }
}
