using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
