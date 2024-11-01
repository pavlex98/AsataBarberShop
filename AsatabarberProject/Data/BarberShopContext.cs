using AsatabarberProject.Models;
using Microsoft.EntityFrameworkCore;
    
    public class BarberShopContext : DbContext
    {
    public BarberShopContext(DbContextOptions<BarberShopContext> options) : base(options)
    {
    }

    public DbSet<Barbers> Barbers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}

