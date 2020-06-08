using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cw11.Controllers
{
    [ApiController]
    [Route("api/hospital")]
    public class HospitalController : ControllerBase
    {

        private readonly IHospitalDbService hospitalDbService;

        public IConfiguration Configuration;

        public HospitalController(IHospitalDbService hospitalDbService, IConfiguration configuration)
        {
            this.hospitalDbService = hospitalDbService;
            this.Configuration = configuration;
        }

        [HttpGet("doctor/{id}")]
        public IActionResult GetDoctor([FromRoute] int id)
        {
            var doctor = hospitalDbService.GetDoctor(id);
            if (doctor!=null)
            {
                return Ok(doctor);
            }
            else
            {
                return BadRequest("There's no doctor with Id "+id+" in the db");
            }
        }

        [HttpDelete("doctor/{id}")]
        public IActionResult DeleteDoctor([FromRoute] int id)
        {
            var doctor = hospitalDbService.DeleteDoctor(id);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            else
            {
                return BadRequest("There's no doctor with Id " + id + " in the db");
            }
        }

        [HttpPost("doctor")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            var newDoctor = hospitalDbService.AddDoctor(doctor);
                return Ok(newDoctor);
        }

        [HttpPut("doctor/{id}")]
        public IActionResult ModifyDoctor([FromRoute] int id)
        {
            var doctor = hospitalDbService.ModifyDoctor(id);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            else
            {
                return BadRequest("There's no doctor with Id " + id + " in the db");
            }
        }

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            hospitalDbService.SeedDbWithData();
            return Ok();
        }

    }
}
