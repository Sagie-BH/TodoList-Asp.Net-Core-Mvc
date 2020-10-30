using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DAL.Helpers.ValidationAttributes;

namespace DAL.Dtos.TodoDtos
{
    public class TodoObjectCreateDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool Done = false;
        public DateTime SubmitTime = DateTime.Now;
    }
}
