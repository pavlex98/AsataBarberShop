using AsatabarberProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class BarberController : Controller
{
    private readonly BarberShopContext _context;

    public BarberController(BarberShopContext context)
    {
        _context = context;

        var barbers = _context.Barbers.ToList();
        Console.WriteLine(barbers.Count); // Проверка, что данные загружаются

    }

    // Отображение списка мастеров
    public async Task<IActionResult> Index()
    {
        var barbers = await _context.Barbers.ToListAsync();
        
        return View(barbers);
    }

    // Форма записи на стрижку
    [Route("Book/Barber/{barberId}")]
    public IActionResult Book(int barberId)
    {
        //var barber = _context.Barbers.Find(barberId);
        //return View(barber);
                
            var barber = _context.Barbers.Find(barberId);
            if (barber == null)
            {
                return NotFound("Барбер не найден." + barber.Name);
            }
            return View(barber);
    }

    [HttpPost]
    public async Task<IActionResult> Book(Appointment appointment)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"BarberId: {appointment.BarberId}, Name: {appointment.ClientName}, Phone: {appointment.ClientPhone}, Date: {appointment.Date}");
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmation");
        }
        Console.WriteLine("Invalid ModelState");
        return View(appointment);
    }

    // Подтверждение записи
    public IActionResult Confirmation()
    {
        return View("Success");
    }

 
}


