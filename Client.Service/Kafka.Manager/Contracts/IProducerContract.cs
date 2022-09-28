using Entity.Manager.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Manager.Contracts
{
    public interface IProducerContract
    {
        Task<CustomerModel> ProduceCustomer(string topic, CustomerModel customer);
    }
}
