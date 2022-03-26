using Microsoft.Extensions.Configuration;
using Sherlock.Apps.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gremlin.Net.Driver;

namespace Sherlock.Apps.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private GremlinClient _gremlinClient;        
        private IPropertyRepository _propertyRepository;
        private IEmployeeRepository _employeeRepository;
        private IGuestRepository _guestRepository;
        private IReservationRepository _reservationRepository;
        private IEmailRequestRepository _emailRequestRepository;
        
        public UnitOfWork(GremlinClient gremlinClient)
        {
            _gremlinClient = gremlinClient;
        }

        public IPropertyRepository PropertyRepository
        {
            get
            {
                if (_propertyRepository == null)
                {
                    _propertyRepository = new PropertyRepository(_gremlinClient);
                }
                return _propertyRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_gremlinClient);
                }
                return _employeeRepository;
            }
        }

        public IGuestRepository GuestRepository
        {
            get
            {
                if (_guestRepository == null)
                {
                    _guestRepository = new GuestRepository(_gremlinClient);
                }
                return _guestRepository;
            }
        }

        public IReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_gremlinClient);
                }
                return _reservationRepository;
            }
        }

        public IEmailRequestRepository EmailRequestRepository
        {
            get
            {
                if (_emailRequestRepository == null)
                {
                    _emailRequestRepository = new EmailRequestRepository(_gremlinClient);
                }
                return _emailRequestRepository;
            }
        }
    }
}
