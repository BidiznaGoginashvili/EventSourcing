using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Infrastructure.DataBase
{
    public class EventSourcingDbContext : DbContext
    {
        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OKIRIV8; Database=Movies; Trusted_Connection=True");
        }
    }
}
