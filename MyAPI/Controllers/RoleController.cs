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
    public class RoleController : Controller
    {
        private readonly DataContext _dbContext;

        public RoleController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Roles.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRole([FromRoute] Guid id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleRequest addRoleRequest)
        {
            var role = new Role()
            {
                RoleID = Guid.NewGuid(),
                Title = addRoleRequest.Title,
                Description = addRoleRequest.Description,
                Permissions = addRoleRequest.Permissions,
            };
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return Ok(role);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRole([FromRoute] Guid id, UpdateRoleRequest updateRoleRequest )
        {
            var role = _dbContext.Roles.Find(id);
            if (role != null)
            {
                role.Title = updateRoleRequest.Title;
                role.Description = updateRoleRequest.Description;
                role.Permissions = updateRoleRequest.Permissions;

                await _dbContext.SaveChangesAsync();
                return Ok(role);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                await _dbContext.SaveChangesAsync();

                return Ok(role);
            }
            return NotFound();
        }
    }
}
