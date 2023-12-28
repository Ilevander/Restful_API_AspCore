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
                AppointmentId = Guid.NewGuid(),
                DoctorId = addAppointmentRequest.DoctorId,
                Number = addAppointmentRequest.Number,
                Type = addAppointmentRequest.Type,
                Date = addAppointmentRequest.Date,
                Description = addAppointmentRequest.Description,
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
                appointment.DoctorId = updateAppointmentRequest.DoctorId;
                appointment.Number = updateAppointmentRequest.Number;
                appointment.Type = updateAppointmentRequest.Type;
                appointment.Date = updateAppointmentRequest.Date;
                appointment.Description = updateAppointmentRequest.Description;
                
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
    

