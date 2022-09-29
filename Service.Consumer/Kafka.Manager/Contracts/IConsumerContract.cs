using Entity.Manager.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Manager.Contracts
{
    public interface IConsumerContract
    {
        Task<CustomerModel> ConsumeCustomer();
    }
}
