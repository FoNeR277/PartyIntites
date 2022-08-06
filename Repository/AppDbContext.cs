using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;

namespace PartyInvites.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<GuestResponse> guestResponses { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PartyInvites;Integrated Security=True;");
        }
    }
}
