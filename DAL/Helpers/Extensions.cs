using DAL.Models;

namespace DAL.Helpers
{
    public static class Extensions
    {
        public static string GetTimeLeft(this TodoObjectModel todoObject)
        {
            return (todoObject.StartTime - todoObject.EndTime).ToString();
        }
    }
}
