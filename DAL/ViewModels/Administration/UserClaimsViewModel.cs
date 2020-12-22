using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels.Administration
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Cliams = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public List<UserClaim> Cliams { get; set; }
    }
}
