using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministery_of_Education.Data;
using Ministery_of_Education.Models.Entities;
using Ministery_of_Education.Models.ViewModel;

namespace Ministery_of_Education.Controllers
{
    [Route("[controller]")]
    public class UserRoleController : Controller
    {
        private readonly MinistryDbContext _ministryDbContext;

        public UserRoleController(MinistryDbContext ministryDbContext)
        {
            _ministryDbContext = ministryDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userRoles = _ministryDbContext.UserRoles.ToList();
            return View(userRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole(UserRoleViewModel roleUser)
        {
            if (ModelState.IsValid)
            {
                var userRoleData = new UserRole
                {
                    RoleName = roleUser.RoleName
                };

                _ministryDbContext.UserRoles.Add(userRoleData);
                await _ministryDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(roleUser);
        }
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userRoleToDelete = await _ministryDbContext.UserRoles.FindAsync(id);
            if (userRoleToDelete != null)
            {
                _ministryDbContext.UserRoles.Remove(userRoleToDelete);
                await _ministryDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, UserRole updatedUserRole)
        {
            var userRoleToUpdate = await _ministryDbContext.UserRoles.FindAsync(id);
            if (userRoleToUpdate != null)
            {
                // Update properties of userRoleToUpdate with values from updatedUserRole
                userRoleToUpdate.Id = updatedUserRole.Id; // Example property
                userRoleToUpdate.RoleName = updatedUserRole.RoleName; // Example property
                                                                      // Add more properties as needed

                await _ministryDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("EditUserRole")]
        public async Task<IActionResult> EditUserRole(UserRole roleUser)
        {
            // (ModelState.IsValid)
            //
            _ministryDbContext.Entry(roleUser).State = EntityState.Modified;
            _ministryDbContext.SaveChanges();
            return RedirectToAction("Index");
            // Retrieve the existing record from the database
            //var existingUserRole = await _ministryDbContext.UserRoles.FindAsync(roleUser.Id);

            //if (existingUserRole == null)
            //{
            //    return NotFound(); // Handle case if role does not exist
            //}

            // Update the properties
            //existingUserRole.RoleName = roleUser.RoleName;

            // Save the changes
            //_ministryDbContext.UserRoles.Update(existingUserRole);
            //await _ministryDbContext.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            //}

            return View(roleUser);
        }

    }
}
