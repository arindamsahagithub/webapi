namespace Sherlock.Apps.Repository.Contract;
    public interface IUnitOfWork : IDisposable
    {
        //  IGremlinHelper GremlinHelperClient { set; }

         

         #region  Repositories
         IGuestRepository GuestRepository { get; }
         IPropertyRepository PropertyRepository { get; }
         IReservationRepository ReservationRepository { get; }
         #endregion

         Task SubmitRequest();
    }