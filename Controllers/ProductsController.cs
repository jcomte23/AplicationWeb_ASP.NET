using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationCRUD_USERS.Data;
using WebApplicationCRUD_USERS.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WebApplicationCRUD_USERS.Controllers
{
    public class ProductsController : Controller
    {
        public readonly DbCleverContext _context;
        public ProductsController(DbCleverContext context)
        {
            _context = context;
        }

        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: ProductsController
        public async Task<IActionResult> FindProduct(string keyword)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.Name.Contains(keyword));
            }

            var productList = await products.ToListAsync();

            return View("Index", productList);

        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Products.FirstOrDefaultAsync(product => product.Id == id));
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Amount,ExpirationDate")] Product _product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(_product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(_product);
            }
            catch
            {
                return View();
            }

        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Products.FirstOrDefaultAsync(product => product.Id == id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


        // GET: ProductsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
            {
                Debug.WriteLine("ese producto no se encontro en la base de datos");
                return NotFound();
            }

            return View(product);

        }


        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
