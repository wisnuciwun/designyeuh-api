using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api_refactor.Models
{
    [Table("Resumes")]
    public class Resumes
    {
        [Key]
        public Guid Id {get; set;}
        public DateTime UploadDate {get; set;}
        public string Link {get; set;}
        public int Downloaded {get; set;}
        public string Author {get; set;}
        public string Filename {get; set;}
        public string Title {get; set;}

    }
}