using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.Services.Doctor_Request;
using MyAPI.Services.Patient_Request;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly DataContext _dbContext;

        public PatientController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Patients.ToListAsync());
        }
        //Get Only one patient
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPatient([FromRoute] Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        //Add Patients
        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientRequest addPatientRequest)
        {
            var patient = new Patient()
            {
                PatientId = Guid.NewGuid(),
                Name = addPatientRequest.Name,
                Mobile = addPatientRequest.Mobile,
                Address = addPatientRequest.Address,
                Email = addPatientRequest.Email,
                Username = addPatientRequest.Username,
                Password = addPatientRequest.Password,
            };
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();

            return Ok(patient);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePatient([FromRoute] Guid id, UpdatePatientRequest updatePatientRequest)
        {
            var patient = _dbContext.Patients.Find(id);
            if (patient != null)
            {
                patient.Name = updatePatientRequest.Name;
                patient.Mobile = updatePatientRequest.Mobile;
                patient.Address = updatePatientRequest.Address;
                patient.Email = updatePatientRequest.Email;
                patient.Username = updatePatientRequest.Username;
                patient.Password = updatePatientRequest.Password;

                await _dbContext.SaveChangesAsync();
                return Ok(patient);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePatient([FromRoute] Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();

                return Ok(patient);
            }
            return NotFound();
        }
    }
}
