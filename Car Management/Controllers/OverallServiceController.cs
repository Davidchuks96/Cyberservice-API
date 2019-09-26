using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Repository;
using Car_Management.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverallServiceController : ControllerBase
    {
        private readonly IOverallService _overallservice;
        private ApplicationDbContext _context;

        public OverallServiceController(IOverallService overallservice,
        ApplicationDbContext context)
        {
            _overallservice = overallservice;
            _context = context;
        }

        [HttpPost]
        [Route("Addservice")]
        public IActionResult post([FromBody] OverallService overallservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                ;
            OverallService overall = new OverallService
            {
                Name = overallservice.Name,
                Time = DateTime.Now
            };
            _overallservice.Create(overall);
            return Ok();
        }

        [HttpGet]
        [Route("Getservice")]
        public OverallService[] Get()
        {
           return _overallservice.GetAllOverallService().ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEachService([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Service = await _context.Overall.FindAsync(id);
            if (Service == null)
            {
                return NotFound();
            }
            return Ok(Service);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var store = _overallservice.GetOverallServiceByid(id);
            _overallservice.Delete(store);
            return Ok();
        }
    }

}
