using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProyect_UCSD.Data;
using MVCProyect_UCSD.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProyect_UCSD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcAppContext _context;

        public HomeController(ILogger<HomeController> logger, MvcAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult Products()
        {
            var data = _context.Products.ToList();
            if(data.Any())
            {
                return View(data);
            }
            else
            {
                return View(null);
            }
            
        }
        public IActionResult Edit(int id)
        {
            var data = _context.Products.Where(x=>x.ProductId == id).ToList();
            if (data.Any())
            {
                return View(data.FirstOrDefault());
            }
            else
            {
                return View(new Product());
            }

        }
        public IActionResult Details(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).ToList();
            if (data.Any())
            {
                return View(data.FirstOrDefault());
            }
            else
            {
                return View(new Product());
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product producto)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products");
            }

            return View(producto);
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).ToList();
            if (data.Any())
            {
                return View(data.FirstOrDefault());
            }
            else
            {
                return View(new Product());
            }

        }
        [HttpPost]
        public async Task<ActionResult> Delete(Product producto)
        {
            var data = _context.Products.Where(x => x.ProductId == producto.ProductId).ToList();
            if (data.Any())
            {
                _context.Products.Remove(data.FirstOrDefault());
                await _context.SaveChangesAsync();
            }



            return RedirectToAction("Products");
        }

        public IActionResult Create()
        {

            return View(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product producto)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products");
            }

            return View(producto);
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
