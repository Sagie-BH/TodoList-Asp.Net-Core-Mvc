using DAL.Helpers;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.DataContext
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<TodoObjectModel> TodoTable { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seeding Data With Extension method located at DAL.Helpers.Extentions
            base.OnModelCreating(builder);
            builder.Seed();

            // Canceling Roles Cascade - Deleting Only when all users are removed from list
            foreach (var foriegnKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foriegnKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
