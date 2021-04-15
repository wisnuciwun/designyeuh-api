using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api.Models
{
    [Table("Donations")]
    public class Donations
    {
        [Key]
        public Guid Id {get; set;}
        public string Payment {get; set;}
        public string ImgLink {get; set;}

    }
}