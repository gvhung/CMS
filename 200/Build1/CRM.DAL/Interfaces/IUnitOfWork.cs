namespace CRM.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get;  }
        void SaveChanges();
    }
}