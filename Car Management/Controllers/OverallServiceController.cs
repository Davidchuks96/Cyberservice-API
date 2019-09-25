using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Management.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OverallServiceController : ControllerBase
    {

        private IService _service;
        private ApplicationDbContext _context;

        public OverallServiceController(IService service,
        ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        [Route("Addservice")]
        public IActionResult post([FromBody] OverallService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                ;
            OverallService overall = new OverallService
            {
                Name = service.Name,
                Time = DateTime.Now
            };
            _service.Create(overall);
            return Ok();
        }
        //[HttpGet]
       // [Route("Getservice")]
       // public OverallService[] Get()
       // {
          //  return _service.GetAlloverservice().ToArray();
       // }
    }

}
