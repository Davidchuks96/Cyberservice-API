using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Repository;
using Car_Management.Services;
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

        [Route("AddService")]
        public IActionResult Post([FromBody]Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //confirm the overall serviceid is correct
            repository.Add(service);
            return Ok();
        }

        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var service = context.Services.Where(b => b.OverallServiceId == id);
            return Ok(service);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            Service service = repository.GetServiceById(id);
            return Ok(service);
        }

        [HttpPost]
        [Route("Edit")]
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
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service service = repository.GetServiceById(id);
            repository.Delete(service);

        }
    }
}
