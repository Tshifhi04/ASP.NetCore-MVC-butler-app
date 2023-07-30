using ButlerApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ButlerApp.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {



        }
        public DbSet<Butler> Butlers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
