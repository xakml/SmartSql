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

        [HttpGet]
        public IActionResult Get()
        {
            var list = this._customerRepository.SelectAll();
            return Ok(list);
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            var list = this._customerRepository.SelectByCondition(new Test.DTO.CustomerQueryConditon() { Id = id });
            return Ok(list);
        }


        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var list = this._customerRepository.SelectByCondition(new Test.DTO.CustomerQueryConditon() {  Name = name});
            return Ok(list);
        }
    }
}
