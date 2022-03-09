// using Sherlock.Apps.Repository.Contract;

// namespace Sherlock.Apps.Repository.Implementation
// {
//     public class UnitOfWork : IUnitOfWork
//     {
//         private readonly GremlinHelper _gremlinHelper;
//                 public UnitOfWork(GremlinHelper gremlinHelper)
//         {
//             _gremlinHelper = gremlinHelper;
//         }
//         #region Repositories
//         private IGuestRepository _guestRepository; 
//         private IReservationRepository _reservationRepository;
//         private IPropertyRepository _propertyRepository;

//         public IGuestRepository GuestRepository {
//             get {
//                 if (_guestRepository == null){
//                     _guestRepository = new GuestRepository(_gremlinHelper);
//                 }
//                 return _guestRepository;
//             }
//         }

//         public IPropertyRepository PropertyRepository {
//             get {
//                 if (_propertyRepository == null){
//                     _propertyRepository = new PropertyRepository(_gremlinHelper);
//                 }
//                 return _propertyRepository;
//             }
//         }

//         public IReservationRepository ReservationRepository {
//             get {
//                 if (_reservationRepository == null){
//                     _reservationRepository = new ReservationRepository(_gremlinHelper);
//                 }
//                 return _reservationRepository;
//             }
//         }

//        #endregion

        
//         public void Dispose()
//         {
//             // do something.
//         }

//         public async Task SubmitRequest()
//         {
//             await _gremlinHelper.SubmitRequest();
//         }
//     }
// }