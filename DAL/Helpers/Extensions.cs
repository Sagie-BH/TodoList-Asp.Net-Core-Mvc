using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
