using DAL.Helpers;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext: IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        public DbSet<TodoObjectModel> TodoTable { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // Seeding Data With Extension method located at DAL.Helpers.Extentions
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
