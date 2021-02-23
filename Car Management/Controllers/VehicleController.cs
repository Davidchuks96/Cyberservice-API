using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyberservice_management.Data;
using Cyberservice_management.Model;
using Cyberservice_management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cyberservice_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle repository;
        private readonly ApplicationDbContext context;

        public VehicleController(
            IVehicle _vehicle,
             ApplicationDbContext _context)
        {
            repository = _vehicle;
            context = _context;
        }

        [HttpPost]
        [Route("AddVehicle")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }      
            repository.Create(vehicle);
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
            var vehicle = context.Vehicles.Where(b => b.Id == id);
            return Ok(vehicle);
        }


        [HttpGet]
        [Route("GetVehicles")]
        //[Authorize(Policy = "RequireLoggedIn")]
        public Vehicle[] Get()
        {
            return repository.GetVehicles().ToArray();
        }


        [HttpPut]
        [Route("Edit")]
       // [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Edit([FromBody] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {

                Vehicle EditVehicle = new Vehicle();
                repository.Update(EditVehicle);

            }
            else
            {
                return BadRequest();
            }
            return Ok(new JsonResult("This Vehicle has been Updated Successfully"));
        }

        [HttpDelete("Delete/{id}")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult DeleteVehicle([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle vehicle = repository.GetByid(id);
            repository.Delete(vehicle);
            return Ok(new JsonResult("Vehicle was Deleted Successfully"));
        }
    }
}