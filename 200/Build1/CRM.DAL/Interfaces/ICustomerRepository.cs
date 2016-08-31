using CRM.DAL.Entities;
namespace CRM.DAL.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer GetCustomerById(long custId);
    }
}
