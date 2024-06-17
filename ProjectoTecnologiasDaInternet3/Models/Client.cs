using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProjectoTecnologiasDaInternet3.Models
{
    public class Client
    {
        [Required]
        [Key]
        //[Range(1, 100, ErrorMessage = "Out Of Range")]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage ="Too long")]
        [RegularExpression(@"^[A-Z](\w*\s?)*$",ErrorMessage = "Don't have capital letters")]
        public string Name { get; set; }

        //[PasswordPropertyText(true)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

    }
}