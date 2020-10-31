using System;
using System.ComponentModel.DataAnnotations;
using static DAL.Helpers.ValidationAttributes;

namespace DAL.ViewModels
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        //public bool IsNew { get; set; }
        [Required]
        [StartDateValidation]
        public DateTime StartTime { get; set; }
        [Required]
        [EndDateValidation]
        public DateTime EndTime { get; set; }
        public DateTime SubmitTime { get; set; }
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
