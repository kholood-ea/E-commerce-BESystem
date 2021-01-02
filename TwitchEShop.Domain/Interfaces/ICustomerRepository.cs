using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Domain.Interfaces
{
  public  interface ICustomerRepository:IRepository<Customer>
    {
        //Task<IEnumerable<Customer>> GetAllCustomersAsync();
        //Task<Customer> GetCustomerByIdAsync(int CustomerId);
        //Task<Customer> CreateCustomerAsync(Customer Customer);
        //Task<bool> UpdateCustomerAsync(Customer updatedCustomer);
        //Task<bool> DeleteCustomerAsync(int CustomerId);
        Task<ContactDetail> AddContactDetail(int customerId, ContactDetail cd);
        Task<bool> RemoveContactDetail(int customerId, int contactDetailId);
        Task<bool> UpdateContactDetails(int customerId, ContactDetail updatedCd);
    }
}
