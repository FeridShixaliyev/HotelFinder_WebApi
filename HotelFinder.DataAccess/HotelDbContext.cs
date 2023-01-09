using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    internal class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-NICFOL4\\SQLEXPRESS01;Database=HotelDb;Trusted_Connection=true");
        }

        public DbSet<Hotel> Hotels { get; set; }   
    }
}
