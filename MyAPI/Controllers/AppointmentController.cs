using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.Services.Doctor_Request;


namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly DataContext _dbContext;

        public AppointmentController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task <IActionResult> GetAppointments()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Appointments.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAppointment([FromRoute] Guid id)
        {
            var appointment = await _dbContext.Appointments.FindAsync(id);
            if(appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddAppointment(AddAppointmentRequest addAppointmentRequest)
        {
            var appointment = new Appointment()
            {
                AppointmentID = Guid.NewGuid(),
                Description = addAppointmentRequest.Description,
                AppointmentDate = addAppointmentRequest.AppointmentDate,
                DoctorID = addAppointmentRequest.DoctorID,
                Doctor = addAppointmentRequest.Doctor,
                PatientID = addAppointmentRequest.PatientID,
                Patient = addAppointmentRequest.Patient,
            };
            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();

            return Ok(appointment);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] Guid id, UpdateAppointmentRequest updateAppointmentRequest)
        {
           var appointment =  _dbContext.Appointments.Find(id);
            if(appointment != null)
            {
                appointment.AppointmentDate = updateAppointmentRequest.AppointmentDate;
                appointment.Description = updateAppointmentRequest.Description;
                appointment.DoctorID = updateAppointmentRequest.DoctorID;
                appointment.Doctor = updateAppointmentRequest.Doctor;
                appointment.PatientID = updateAppointmentRequest.PatientID;
                appointment.Patient = updateAppointmentRequest.Patient;
                
                await _dbContext.SaveChangesAsync();
                return Ok(appointment);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task <IActionResult> DeleteAppointment([FromRoute] Guid id )
        {
            var appointment = await _dbContext.Appointments.FindAsync(id);
            if(appointment != null)
            {
                _dbContext.Appointments.Remove(appointment);
               await _dbContext.SaveChangesAsync();

                return Ok(appointment);
            }
            return NotFound();
        }
    }
}
    

