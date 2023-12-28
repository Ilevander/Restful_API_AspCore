using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.Services.Doctor_Request;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly DataContext _dbContext;

        public DoctorController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task <IActionResult> GetDoctors()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Doctors.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDoctor([FromRoute] Guid id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            if(doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            var doctor = new Doctor()
            {
                DoctorId = Guid.NewGuid(),
                Name = addDoctorRequest.Name,
                Specialist = addDoctorRequest.Specialist,
                Mobile = addDoctorRequest.Mobile,
                Email = addDoctorRequest.Email,
                Username = addDoctorRequest.Username,
                Password = addDoctorRequest.Password,
                Address = addDoctorRequest.Address
            };
            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();

            return Ok(doctor);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDoctor([FromRoute] Guid id, UpdateDoctorRequest updatDoctorRequest)
        {
           var doctor =  _dbContext.Doctors.Find(id);
            if(doctor != null)
            {
                doctor.Name = updatDoctorRequest.Name;
                doctor.Specialist = updatDoctorRequest.Specialist;
                doctor.Mobile = updatDoctorRequest.Mobile;
                doctor.Email = updatDoctorRequest.Email;
                doctor.Username = updatDoctorRequest.Username;
                doctor.Password = updatDoctorRequest.Password;
                doctor.Address = updatDoctorRequest.Address;

                await _dbContext.SaveChangesAsync();
                return Ok(doctor);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task <IActionResult> DeleteDoctor([FromRoute] Guid id )
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            if(doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
               await _dbContext.SaveChangesAsync();

                return Ok(doctor);
            }
            return NotFound();
        }
    }
}
    

