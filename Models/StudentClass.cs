using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LoginCrud.Models
{
    public class StudentClass
    {
        
        [Key]
        public int Empid { get; set; } = 0;

        [Required(ErrorMessage = "Enter Empluyee name")]
        [Display(Name = "Empluyee Name")]
        public String Empname { get; set; } = "";

        [Required(ErrorMessage = "Enter Emaul")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter emp age")]
        [Display(Name = "Age")]
        [Range(20, 50)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter emp salary")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }
    }
}
