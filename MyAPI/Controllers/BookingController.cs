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
    public class BookingController : Controller
    {
        private readonly DataContext _dbContext;

        public BookingController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Bookings.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid id)
        {
            var booking = await _dbContext.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingRequest addBookingRequest)
        {
            var booking = new Booking()
            {
                BookingID = Guid.NewGuid(),
                BookingDate = addBookingRequest.BookingDate,
                PatientID = addBookingRequest.PatientID,
                Patient = addBookingRequest.Patient,
                ClinicID = addBookingRequest.ClinicID,
                Clinic = addBookingRequest.Clinic
            };
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] Guid id, UpdateBookingRequest updateBookingRequest)
        {
            var booking = _dbContext.Bookings.Find(id);
            if (booking != null)
            {
                booking.BookingDate = updateBookingRequest.BookingDate;
                booking.PatientID = updateBookingRequest.PatientID;
                booking.Patient = updateBookingRequest.Patient;
                booking.ClinicID = updateBookingRequest.ClinicID;
                booking.Clinic = updateBookingRequest.Clinic;

                await _dbContext.SaveChangesAsync();
                return Ok(booking);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
        {
            var booking = await _dbContext.Bookings.FindAsync(id);
            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
                await _dbContext.SaveChangesAsync();

                return Ok(booking);
            }
            return NotFound();
        }
    }
}
