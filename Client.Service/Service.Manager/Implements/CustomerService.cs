using Entity.Manager.Customer;
using Kafka.Manager.Contracts;
using Service.Manager.Contracts;

namespace Service.Manager.Implements
{
    public class CustomerService : ICustomer
    {
        private readonly IProducerContract _producer;

        public CustomerService(IProducerContract producer)
        {
            _producer = producer;
        }
        public async Task<CustomerModel> ProcessCustomer(CustomerModel customer)
        {
            return await _producer.ProduceCustomer("customer-topic", customer);
        }
    }
}
