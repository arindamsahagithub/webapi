using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock.Apps.Repository.Contract
{
    public interface IUnitOfWork
    {
        #region  Repositories
        IPropertyRepository PropertyRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IGuestRepository GuestRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IEmailRequestRepository EmailRequestRepository { get; }
        #endregion
    }
}
