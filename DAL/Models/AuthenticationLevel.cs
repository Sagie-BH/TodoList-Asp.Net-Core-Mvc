using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class AuthenticationLevel
    {
        [Key]
        public int AuthId { get; set; }
        [Required]
        public string AuthName { get; set; }
        [ForeignKey("AuthLevelRefId")]
        public ICollection<UserModel> Users { get; set; }
    }
}
