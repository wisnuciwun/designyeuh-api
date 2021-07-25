using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api.Models
{
    [Table("AspNetUsers")]
    public class AspNetUsers
    {
        [Key]
        public Guid Id {get; set;}
        public string UserName {get; set;}
        public string Role_Privileges {get; set;}
        public string Works {get; set;}
        public string Nationality {get; set;}
        public DateTime Born {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime Created_Date {get; set;}
        public Guid SecurityStamp {get; set;}

    }
}