using System;
using System.Linq;
using System.Threading.Tasks;
using Cyberservice_management.Data;
using Cyberservice_management.Model;
using Cyberservice_management.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberservice_management.Controllers
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
        [Route("AddOverallservice")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult post([FromBody] OverallService overallservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            OverallService overall = new OverallService
            {
                Name = overallservice.Name,
                Time = DateTime.Now
            };
            _overallservice.Create(overall);
            return Ok(new JsonResult("The Service was Added Successfully"));
        }

        [HttpGet]
        [Route("Getservice")]
        [Authorize(Policy = "RequireLoggedIn")]
        public OverallService[] Get()
        {
           return _overallservice.GetAllOverallService().ToArray();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "RequireLoggedIn")]
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
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = _overallservice.GetOverallServiceByid(id);
            _overallservice.Delete(service);
           return Ok();
        }
    }

}
