using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Dtos.TodoDtos
{
    public class TodoObjectCreateDto
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public DateTime SubmitTime = DateTime.Now;
        [Required]
        [StringLength(50, ErrorMessage = "Title length must be less then 50" )]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public int Priority { get; set; }
        public bool Done = false;
    }
}
