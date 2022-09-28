using Entity.Manager.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Manager.Contracts;

namespace Customer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpPost]
        public async Task<CustomerModel> ProcessCustomer([FromBody] CustomerModel customer)
        {
            return await _customer.ProcessCustomer(customer);
        }
    }
}
