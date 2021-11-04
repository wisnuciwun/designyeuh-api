using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api_refactor.Models
{
    [Table("Contributors")]
    public class Contributors
    {
        [Key]
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Instagram {get; set;}
        public string Facebook {get; set;}
        public string Twitter {get; set;}
        public string Creation {get; set;}
        public string ImgLink {get; set;}
        public string Address {get; set;}

    }
}