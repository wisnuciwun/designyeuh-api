using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Identity;

namespace designyeuh_api.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Role_Privileges {get; set;}
        public string Works {get; set;}
        public string Nationality {get; set;}
        public DateTime Born {get; set;}
        public DateTime Created_Date {get; set;}

    }
    
}