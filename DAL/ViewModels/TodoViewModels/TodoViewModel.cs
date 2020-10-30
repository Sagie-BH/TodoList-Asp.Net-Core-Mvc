using TodoList.Dtos.TodoDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TodoList.Helpers.ValidationAttributes;

namespace TodoList.ViewModels
{
    public class TodoViewModel
    {
        public bool IsNew { get; set; }
        [Required]
        [StartDateValidation]
        public DateTime StartTime { get; set; }
        [Required]
        [EndDateValidation]
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title length must be less then 50")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        public bool Done { get; set; }

    }
}
