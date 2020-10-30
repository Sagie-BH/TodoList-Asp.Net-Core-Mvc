using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Dtos.UserDtos
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "User name length must be less than 50")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int AuthLevelRefId { get; set; }
    }
}
