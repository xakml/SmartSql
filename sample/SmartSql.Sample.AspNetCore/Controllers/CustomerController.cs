using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using SmartSql.Sample.AspNetCore.DyRepositories;
using SmartSql.Sample.AspNetCore.Service;
using SmartSql.Sample.Repos;
using SmartSql.Test.Entities;

namespace SmartSql.Sample.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerService _customerService;
        public CustomerController(ICustomerRepository userRepository
           , CustomerService userService)
        {
            _customerRepository = userRepository;
            _customerService = userService;
        }

        [HttpPost]
        public IActionResult Add([FromBody]Customer cust)
        {
            long id = this._customerService.AddWithTran(cust);
            return Ok(id);
        }
    }
}
