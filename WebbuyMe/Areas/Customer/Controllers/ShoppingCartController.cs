using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebbuyMe.Data;
using WebbuyMe.Extensions;
using WebbuyMe.Models;
using WebbuyMe.Models.ViewModel;

namespace WebbuyMe.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;

            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Products>()
            };
        }

        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart.Count > 0)
            {
                foreach (var cartItem in lstShoppingCart)
                {
                    Products prod = _db.products.Include(p => p.SpecialTags).Include(p => p.ProductTypes).FirstOrDefault(p => p.Id == cartItem);
                    ShoppingCartVM.Products.Add(prod);
                }
            }
            return View(ShoppingCartVM);
        }
    }
}