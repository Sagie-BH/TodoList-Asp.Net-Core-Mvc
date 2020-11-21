using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Helpers
{
    public static class Extensions
    {
        public static string GetTimeLeft(this TodoObjectModel todoObject)
        {
            return (todoObject.StartTime - todoObject.EndTime).ToString();
        }


        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
           new ApplicationUser
           {
               UserName = "Sagie",
               Email = "sagie@gmail.com",
               PasswordHash = "12345"
           });
        }
    }
}
