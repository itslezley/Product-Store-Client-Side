using Lezlab.Business;
using Lezlab.Data;
using Lezlab.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lezlab.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _dbContext;
        private HashPass hashPassword = new HashPass();
        private LinkedList<Product> cart = new LinkedList<Product>();

        public HomeController(ApplicationDBContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.ToListAsync();
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            ViewData["CustomerName"] = HttpContext.Session.GetString("CustomerName");
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            ViewData["CustomerName"] = HttpContext.Session.GetString("CustomerName");
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(Customer customer)
        {
                var _customer = await _dbContext.Customers.FirstOrDefaultAsync(x=> x.email==customer.email && x.password==customer.password);

                if(_customer != null) {
                HttpContext.Session.SetString("Username", _customer.email);
                HttpContext.Session.SetString("CustomerName", _customer.surname);
                HttpContext.Session.SetInt32("UserId", _customer.customerId);
                
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User login error.");
                }
            
            return View(customer);

        
    }
        [HttpGet]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "home");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            ViewData["CustomerName"] = HttpContext.Session.GetString("CustomerName");
            return View();
        }

            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(Customer customer)
        {
           customer.password = hashPassword.HashPassword(customer.password);
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            
            
            HttpContext.Session.SetString("Username", customer.email);
            HttpContext.Session.SetString("CustomerName", customer.name);
            HttpContext.Session.SetInt32("UserId", customer.customerId);

            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Image.CopyToAsync(memoryStream);
                        product.Image = memoryStream.ToArray();  // Convert to byte[]
                    }
                }
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);

        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
          var products = await  _dbContext.Products.ToListAsync();

            if(products == null)
            {
                products=new List<Product>();
                return View(products);
            }
            return View(products);
        }

        [HttpPost]
        public IActionResult AddCart(Product product)
        {
            this.cart.AddFirst(product);

            return View();
        }

        [HttpGet]
        public IActionResult getCart()
        {
            return View(cart);
        }

        [HttpGet]
        public async Task<IActionResult> profile()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            ViewData["CustomerName"] = HttpContext.Session.GetString("CustomerName");
            int userId = HttpContext.Session.GetInt32("UserId") ?? -1;

            if (userId == -1)
            {
                return RedirectToAction("login", "Home");
            }

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x=> x.customerId==userId);
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
