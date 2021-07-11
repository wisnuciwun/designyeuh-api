using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api.Models
{
    [Table("Images")]
    public class Images
    {
        [Key]
        public Guid Id {get; set;}
        public DateTime UploadDate {get; set;}
        public string Link_Mobile {get; set;}
        public string Link {get; set;}
        public int Downloaded {get; set;}
        public string Author {get; set;}
        public string Filename {get; set;}
        public string Title {get; set;}

    }
}