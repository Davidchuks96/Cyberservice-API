using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController:ControllerBase
    {
        private readonly IService _service;
        private ApplicationDbContext _context;

        public ServiceController(IService service,
        ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        [Route("Addservice")]
        public IActionResult Post([FromBody] Service newService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            Service service = new Service
            {
                Name = newService.Name,
                Description = newService.Description,
                SerialNo = newService.SerialNo,

            };
            _service.Create(service);
            return Ok();
        }
    }
}
