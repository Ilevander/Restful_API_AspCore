using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
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
    }
}
    

