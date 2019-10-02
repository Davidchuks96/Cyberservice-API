using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Management.Controllers
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

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            Vehicle vehicle = repository.GetByid(id);
            return Ok(vehicle);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {

                Vehicle EditedVehicle = new Vehicle();
                repository.Update(EditedVehicle);

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
            Vehicle vehicle = repository.GetByid(id);
            repository.Delete(vehicle);

        }
    }
}