using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MultitenantPrueba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantPrueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly SampleContext _context;
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;

        public CustomerController(SampleContext context,  IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("tenant-b")]
        public IActionResult Get()
        {
            return Ok(_context.Customers.Select(x => new
            {
                id = x.CustomerId,
                name = x.Name,
                address = x.Address,
                number = x.PhoneNumber,
                date = x.DateOfBirth
            }).ToList());
        }
    }
}
