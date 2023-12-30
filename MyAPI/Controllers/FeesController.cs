using Doctors.Data;
using Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.Services.Doctor_Request;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeesController : Controller
    {
        private readonly DataContext _dbContext;

        public FeesController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task<IActionResult> GetFeess()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Fees.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetFees([FromRoute] Guid id)
        {
            var fees = await _dbContext.Appointments.FindAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            return Ok(fees);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddFees(AddFeesRequest addFeesRequest)
        {
            var fees = new Fees()
            {
                FeeID = Guid.NewGuid(),
                Amount = addFeesRequest.Amount,
                DoctorID = addFeesRequest.DoctorID,
                Doctor = addFeesRequest.Doctor,
                
            };
            await _dbContext.Fees.AddAsync(fees);
            await _dbContext.SaveChangesAsync();

            return Ok(fees);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateFees([FromRoute] Guid id, UpdateFeestRequest updateFeestRequest)
        {
            var fees = _dbContext.Fees.Find(id);
            if (fees != null)
            {
                fees.Amount = updateFeestRequest.Amount;
                fees.DoctorID = updateFeestRequest.DoctorID;
                fees.Doctor = updateFeestRequest.Doctor;

                await _dbContext.SaveChangesAsync();
                return Ok(fees);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteFees([FromRoute] Guid id)
        {
            var fees = await _dbContext.Fees.FindAsync(id);
            if (fees != null)
            {
                _dbContext.Fees.Remove(fees);
                await _dbContext.SaveChangesAsync();

                return Ok(fees);
            }
            return NotFound();
        }
    }
}
