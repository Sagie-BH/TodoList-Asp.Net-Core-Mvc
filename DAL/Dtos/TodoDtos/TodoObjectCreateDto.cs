using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DAL.Helpers.ValidationAttributes;

namespace DAL.Dtos.TodoDtos
{
    public class TodoObjectCreateDto
    {
        [Required]
        [StartDateValidation]
        public DateTime StartTime { get; set; }
        [Required]
        [EndDateValidation]
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title length must be less then 50" )]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0-100")]
        public int Priority { get; set; }
        public bool Done = false;
        public DateTime SubmitTime = DateTime.Now;
    }
}
