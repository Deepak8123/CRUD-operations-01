using AspCodeFirst_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspCodeFirst_01.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDB.StudentsDB.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.StudentsDB.AddAsync(std);
                await studentDB.SaveChangesAsync();
                TempData["Insert_Success"] = "Data Has Been Inserted Successfully...";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.StudentsDB == null)
            {
                return NotFound();
            }

            var stdData = await studentDB.StudentsDB.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDB.StudentsDB == null)
            {
                return NotFound();
            }

            var stdData = await studentDB.StudentsDB.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentDB.StudentsDB.Update(std);
                await studentDB.SaveChangesAsync();
                TempData["Update_Success"] = "Data Has Been Updated Successfully...";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.StudentsDB == null)
            {
                return NotFound();
            }

            var stdData = await studentDB.StudentsDB.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await studentDB.StudentsDB.FindAsync(id);
            if (stdData != null)
            {
                studentDB.StudentsDB.Remove(stdData);
            }
            await studentDB.SaveChangesAsync();
            TempData["Delete_Success"] = "Data Has Been Deleted Successfully...";
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
