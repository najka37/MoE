using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministery_of_Education.Data;
using Ministery_of_Education.Models.Entities;
using Ministery_of_Education.Models.ViewModel;

namespace Ministery_of_Education.Controllers
{
    [Route("[controller]")]
    public class SchoolController : Controller
    {
        private readonly MinistryDbContext _ministryDbContext;

        public SchoolController(MinistryDbContext ministryDbContext)
        {
            _ministryDbContext = ministryDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var schools = _ministryDbContext.Schools.ToList();
            var schooltype =  _ministryDbContext.SchoolTypes.ToList(); // Fetch the list of departments

            ViewData["SchoolType"] = schooltype;
            return View(schools);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool(SchoolViewModel schoolViewModel)
        {
            if (ModelState.IsValid)
            {
                var school = new School
                {
                    Name = schoolViewModel.Name,
                    Location = schoolViewModel.Location,
                    District = schoolViewModel.District,
                    Type = schoolViewModel.Type,
                    Email = schoolViewModel.Email
                };

                _ministryDbContext.Schools.Add(school);
                await _ministryDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolViewModel);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var schoolToDelete = await _ministryDbContext.Schools.FindAsync(id);
            if (schoolToDelete != null)
            {
                _ministryDbContext.Schools.Remove(schoolToDelete);
                await _ministryDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, SchoolViewModel schoolViewModel)
        {
            var schoolToUpdate = await _ministryDbContext.Schools.FindAsync(id);
            if (schoolToUpdate != null)
            {
                schoolToUpdate.Name = schoolViewModel.Name;
                schoolToUpdate.Location = schoolViewModel.Location;
                schoolToUpdate.District = schoolViewModel.District;
                schoolToUpdate.Type = schoolViewModel.Type;
                schoolToUpdate.Email = schoolViewModel.Email;

                await _ministryDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("EditSchool")]
        public async Task<IActionResult> EditSchool(SchoolViewModel schoolViewModel)
        {
            var schoolToUpdate = await _ministryDbContext.Schools.FindAsync(schoolViewModel.SchoolID);
            if (schoolToUpdate != null)
            {
                schoolToUpdate.Name = schoolViewModel.Name;
                schoolToUpdate.Location = schoolViewModel.Location;
                schoolToUpdate.District = schoolViewModel.District;
                schoolToUpdate.Type = schoolViewModel.Type;
                schoolToUpdate.Email = schoolViewModel.Email;

                await _ministryDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
