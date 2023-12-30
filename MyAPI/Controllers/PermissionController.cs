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
    public class PermissionController : Controller
    {
        private readonly DataContext _dbContext;

        public PermissionController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get the List of all Doctors
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            //usinf LINQ to get all the data: using ok response
            return Ok(await _dbContext.Permissions.ToListAsync());
        }
        //Get Only one doctor
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPermission([FromRoute] Guid id)
        {
            var permission = await _dbContext.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }
        //Add Doctors
        [HttpPost]
        public async Task<IActionResult> AddPermission(AddPermissionRequest addPermissionRequest)
        {
            var permission = new Permission()
            {
                PermissionID = Guid.NewGuid(),
                RoleID = addPermissionRequest.RoleID,
                Title = addPermissionRequest.Title,
                Module = addPermissionRequest.Module,
                Description = addPermissionRequest.Description,
                Role = addPermissionRequest.Role,
            };
            await _dbContext.Permissions.AddAsync(permission);
            await _dbContext.SaveChangesAsync();

            return Ok(permission);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePermission([FromRoute] Guid id, UpdatePermissionRequest updatePermissionRequest)
        {
            var permission = _dbContext.Permissions.Find(id);
            if (permission != null)
            {
                permission.RoleID = updatePermissionRequest.RoleID;
                permission.Title = updatePermissionRequest.Title;
                permission.Module = updatePermissionRequest.Module;
                permission.Description = updatePermissionRequest.Description;
                permission.Role = updatePermissionRequest.Role;

                await _dbContext.SaveChangesAsync();
                return Ok(permission);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePermission([FromRoute] Guid id)
        {
            var permission = await _dbContext.Permissions.FindAsync(id);
            if (permission != null)
            {
                _dbContext.Permissions.Remove(permission);
                await _dbContext.SaveChangesAsync();

                return Ok(permission);
            }
            return NotFound();
        }
    }
}
