using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministery_of_Education.Data;
using Ministery_of_Education.Models.Entities;
using Ministery_of_Education.Models.ViewModels;
using System.Threading.Tasks;

namespace Ministery_of_Education.Controllers
{
    public class SchoolTypeController : Controller
    {
        private readonly MinistryDbContext _context;

        public SchoolTypeController(MinistryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var schoolTypes = _context.SchoolTypes.ToList();
            return View(schoolTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchoolType(AddSchoolTypeViewModel schoolType)
        {
            if (ModelState.IsValid)
			{
				var _SchoolTypes = new SchoolType
				{
					Name = schoolType.Name
				};
				_context.SchoolTypes.Add(_SchoolTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Index", _context.SchoolTypes.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> EditSchoolType(SchoolType schoolType)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(schoolType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Index", _context.SchoolTypes.ToList());
        }


        public async Task<IActionResult> Delete(int id)
        {
            var userRoleToDelete = await _context.SchoolTypes.FindAsync(Convert.ToInt64(id));
            if (userRoleToDelete != null)
            {
                _context.SchoolTypes.Remove(userRoleToDelete);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var sch = _context.SchoolTypes.Find(id);
        //    if (sch != null)
        //    {
        //        _context.SchoolTypes.Remove(sch);
        //         _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
