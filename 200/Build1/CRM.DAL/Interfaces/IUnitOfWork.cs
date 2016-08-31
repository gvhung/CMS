namespace CRM.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }

        void SaveChanges();
    }
}