using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Model;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class valuesController : ControllerBase
    {
        private IvehicleRepository _ivehiclerepository;

        
        public valuesController( IvehicleRepository ivehicleRepository)
        {
            _ivehiclerepository = ivehicleRepository;
        }

        // GET: api/values
        [HttpGet]
        
        public IActionResult GetAllVehicles()
        {
            //return _context.TodoItems;
            var result= _ivehiclerepository.GetAllVehicle();
            return Ok(result);
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public IActionResult GetVehicleByID([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var todoItem = await _context.TodoItems.FindAsync(id);
            var result = _ivehiclerepository.GetVehicle(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        //PUT: api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id,[FromBody] Vehicle vehicle)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!=vehicle.id)
            {
                return BadRequest();
            }

            var result = await _ivehiclerepository.Update(vehicle);
            

                return Ok(result);
           
        }

        // POST: api/vehicles
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Vehicle>> Create(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await _ivehiclerepository.Create(vehicle);
            return CreatedAtAction(nameof(GetVehicleByID), new { id = vehicle.id }, result);
        }
        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!=0)
            {
                var result = await _ivehiclerepository.Delete(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }







     
    }
}