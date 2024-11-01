using AsatabarberProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsatabarberProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BarberShopContext _context;

        public HomeController(BarberShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var barbers = _context.Barbers.ToList();
            return View(barbers);
        }
    }

}
