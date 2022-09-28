using Entity.Manager.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager.Contracts
{
    public interface ICustomer
    {
        Task<CustomerModel> ProcessCustomer(CustomerModel customer);
    }
}
