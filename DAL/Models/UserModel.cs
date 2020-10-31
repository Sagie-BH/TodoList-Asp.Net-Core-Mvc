using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column("Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int AuthLevelRefId { get; set; }
        public ICollection<TodoObjectModel> TodoList { get; set; }
    }
}
