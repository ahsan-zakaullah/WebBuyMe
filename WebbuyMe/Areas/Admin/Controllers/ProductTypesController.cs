using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebbuyMe.Data;

namespace WebbuyMe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var dataList = _db.productTypes.ToList();

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
        public async Task<IActionResult> Create(ProductTypes product)
        {
            if (ModelState.IsValid)
            {
                _db.productTypes.Add(product);
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
            return View(_db.productTypes.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes product)
        {
            if (ModelState.IsValid)
            {
                _db.productTypes.Update(product);
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
            return View(_db.productTypes.Find(id));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var del = await _db.productTypes.FindAsync(id);
            _db.Remove(del);
            await _db.SaveChangesAsync();
            TempData["test"] = "Data has been Deleted";
            return RedirectToAction(nameof(Index));
        }

    }
}