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
    public class ScheduleController : Controller
    {
        private readonly DataContext _dbContext;

        public ScheduleController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Patients
        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Schedules.ToListAsync());
        }
        //Get Only one patient
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSchedule([FromRoute] Guid id)
        {
            var schdule = await _dbContext.Schedules.FindAsync(id);
            if (schdule == null)
            {
                return NotFound();
            }
            return Ok(schdule);
        }
        //Add Patients
        [HttpPost]
        public async Task<IActionResult> AddSchedule(AddScheduleRequest addScheduleRequest)
        {
            var schedule = new Schedule()
            {
                ScheduleID = Guid.NewGuid(),
                StartTime = addScheduleRequest.StartTime,
                EndTime = addScheduleRequest.EndTime,
                DoctorID = addScheduleRequest.DoctorID,
                Doctor = addScheduleRequest.Doctor,
            };
            await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();

            return Ok(schedule);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSchedule([FromRoute] Guid id, UpdateScheduleRequest updateScheduleRequest)
        {
            var schedule = _dbContext.Schedules.Find(id);
            if (schedule != null)
            {
                schedule.StartTime = updateScheduleRequest.StartTime;
                schedule.EndTime = updateScheduleRequest.EndTime;
                schedule.DoctorID = updateScheduleRequest.DoctorID;
                schedule.Doctor = updateScheduleRequest.Doctor;
                

                await _dbContext.SaveChangesAsync();
                return Ok(schedule);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSchedule([FromRoute] Guid id)
        {
            var schedule = await _dbContext.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _dbContext.Schedules.Remove(schedule);
                await _dbContext.SaveChangesAsync();

                return Ok(schedule);
            }
            return NotFound();
        }
    }
}
