using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartSql.Sample.AspNetCoreMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DyRepositories.ISysRoleRepository _customerRepository;
        public RoleController(DyRepositories.ISysRoleRepository userRepository)
        {
            _customerRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get(long id)
        {
            var list = this._customerRepository.SelectSysRoleById(id);
            return Ok(list);
        }
    }
}
