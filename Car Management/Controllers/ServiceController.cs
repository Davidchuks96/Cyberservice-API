using Cyberservice_management.Data;
using Cyberservice_management.Model;
using Cyberservice_management.Repository;
using Cyberservice_management.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController:ControllerBase
    {

        private ApplicationDbContext context;
        private IService repository;
        private IOverallService overallservice;

        public ServiceController(ApplicationDbContext _context,
            IService _service,
            IOverallService _overall)
        {
            overallservice = _overall;
            context = _context;
            repository = _service;
        }

        [HttpPost]
        [Route("AddService")]
       //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Post([FromBody]Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //confirm the overall serviceid is correct
            repository.Add(service);
            return Ok(new JsonResult("The Service was Added Successfully"));
        }

        [HttpGet("{id}")]
        [Route("Get/{id}")]
        //[Authorize(Policy = "RequireLoggedIn")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var service = context.Services.Where(b => b.OverallServiceId == id);
            return Ok(service);
        }

        [HttpPut]
        [Route("Edit")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Edit([FromBody] Service service)
        {
            if (ModelState.IsValid)
            {

                Service EditedService = new Service();
                repository.Update(EditedService);

            }
            else
            {
                return BadRequest();
            }
            return Ok(new JsonResult("Updated Successfully"));
        }

        [HttpDelete("Delete/{id}")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Service service = repository.GetServiceById(id);
            repository.Delete(service);
            return Ok(new JsonResult ("The Service was Deleted Successfully"));
        }
    }
}
