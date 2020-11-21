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
            modelBuilder.Entity<UserModel>().HasData(
           new UserModel
           {
               ID = 1,
               UserName = "Sagie",
               Email = "sagie@gmail.com",
               Password = "12345",
               Role = "admin"
           });
        }
    }
}
