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
    public class UserController : Controller
    {

        private readonly DataContext _dbContext;

        public UserController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Patients
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Users.ToListAsync());
        }
        //Get Only one patient
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //Add Patients
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                UserID = Guid.NewGuid(),
                RoleID = addUserRequest.RoleID,
                UserName = addUserRequest.UserName,
                Password = addUserRequest.Password,
                Email = addUserRequest.Email,
                Date = addUserRequest.Date,
                Address = addUserRequest.Address,
                Role = addUserRequest.Role,
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                user.RoleID = updateUserRequest.RoleID;
                user.UserName = updateUserRequest.UserName;
                user.Password = updateUserRequest.Password;
                user.Email = updateUserRequest.Email;
                user.Date = updateUserRequest.Date;
                user.Address = updateUserRequest.Address;
                user.Role = updateUserRequest.Role;

                await _dbContext.SaveChangesAsync();
                return Ok(user);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }
    }
}
