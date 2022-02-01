using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task1.Models
{
    public class Student
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage ="ID Must Follow XX-XXXXX-X")]
        public int Id { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}