using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebbuyMe.Data;
using WebbuyMe.Models;

namespace WebbuyMe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var dataList = _db.specialTags.ToList();

            if (TempData["test"] != null)
            {

                ViewBag.employee = TempData["test"].ToString();

            }


            return View(dataList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags tags)
        {
            if (ModelState.IsValid)
            {
                _db.specialTags.Add(tags);
                await _db.SaveChangesAsync();
                TempData["test"] = "Data has been added";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_db.specialTags.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags tags)
        {
            if (ModelState.IsValid)
            {
                _db.specialTags.Update(tags);
                await _db.SaveChangesAsync();
                TempData["test"] = "Data has been Edit";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_db.specialTags.Find(id));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var del = await _db.specialTags.FindAsync(id);
            _db.Remove(del);
            await _db.SaveChangesAsync();
            TempData["test"] = "Data has been Deleted";
            return RedirectToAction(nameof(Index));
        }

    }
}