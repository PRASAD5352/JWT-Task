using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontCrest_Task_ClietSide.Models
{
    public class Student
    {
        public int sid { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Charecters Required")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Charecters Required")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",ErrorMessage = "Minimum eight characters, at least one letter and one number")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Enter 10 Digit Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Adhar No")]
        [RegularExpression("[0-9]{12}", ErrorMessage = "Enter 12 Digit Number")]
        public string Adharno { get; set; }
        public string Profile { get; set; }
        public string Role { get; set; }
    }
}