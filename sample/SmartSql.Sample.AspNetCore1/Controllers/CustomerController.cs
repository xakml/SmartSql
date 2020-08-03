using Microsoft.AspNetCore.Mvc;
using SmartSql.Sample.AspNetCore1.DyRepositories;
using SmartSql.Test.Entities;

namespace SmartSql.Sample.AspNetCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository userRepository)
        {
            _customerRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer cust)
        {
            long id = this._customerRepository.Insert(cust);
            return Ok(id);
        }
    }
}
