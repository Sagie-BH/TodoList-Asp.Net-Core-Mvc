using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Dtos
{
    public class TodoObjectCreateDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string UserEmail { get; set; }

        public bool Done = false;
        public DateTime SubmitTime = DateTime.Now;
    }
}
