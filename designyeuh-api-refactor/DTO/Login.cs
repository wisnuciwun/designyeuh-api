using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace designyeuh_api_refactor.DTO
{
    public class Login
    {
        public string Email {get; set;}
        public string Password {get; set;}

    }
}