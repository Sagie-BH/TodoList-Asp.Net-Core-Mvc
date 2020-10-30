using TodoList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Helpers
{
    public static class Extensions
    {
        public static string GetTimeLeft(this TodoObjectModel todoObject)
        {
            return (todoObject.StartTime - todoObject.EndTime).ToString();
        }
    }
}
