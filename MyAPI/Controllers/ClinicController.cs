using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.Services.Doctor_Request;
using MyAPI.Services.Patient_Request;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : Controller
    {
        private readonly DataContext _dbContext;

        public ClinicController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task<IActionResult> GetClinics()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Clinics.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClinic([FromRoute] Guid id)
        {
            var clinic = await _dbContext.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddClinic(AddClinicRequest addClinicRequest)
        {
            var clinic = new Clinic()
            {
                ClinicID = Guid.NewGuid(),
                ClinicName = addClinicRequest.ClinicName,
                Location = addClinicRequest.Location,
                Doctors = addClinicRequest.Doctors,
                Bookings = addClinicRequest.Bookings,
            };
            await _dbContext.Clinics.AddAsync(clinic);
            await _dbContext.SaveChangesAsync();

            return Ok(clinic);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateClinic([FromRoute] Guid id, UpdateClinicRequest updateClinicRequest)
        {
            var clinic = _dbContext.Clinics.Find(id);
            if (clinic != null)
            {
                clinic.ClinicName = updateClinicRequest.ClinicName;
                clinic.Location = updateClinicRequest.Location;
                clinic.Doctors = updateClinicRequest.Doctors;
                clinic.Bookings = updateClinicRequest.Bookings;

                await _dbContext.SaveChangesAsync();
                return Ok(clinic);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClinic([FromRoute] Guid id)
        {
            var clinic = await _dbContext.Clinics.FindAsync(id);
            if (clinic != null)
            {
                _dbContext.Clinics.Remove(clinic);
                await _dbContext.SaveChangesAsync();

                return Ok(clinic);
            }
            return NotFound();
        }
    }
}
