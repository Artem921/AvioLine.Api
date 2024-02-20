using AvioLine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvioLine.Dal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TicketEntity> Tickets { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();

        }









    }
}

