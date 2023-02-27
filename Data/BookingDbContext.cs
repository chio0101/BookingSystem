using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<HourModel> Hours { get; set; }
        public DbSet<MinModel> Mins { get; set; }
    }
}