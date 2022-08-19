using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCDb.Models
{
    public partial class Emp
    {
        [Display(Name = "Emp Code")]
        public int Id { get; set; }
        [Display(Name = "Emp Name")]
        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        [Display(Name = "Salary")]
        [Range(10000, 90000, ErrorMessage = "Salary must be betweeen 10000 to 90000")]
        public int? Salary { get; set; }
        [Display(Name ="Department ID")]
        public int? Deptid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        [DOBCheck(ErrorMessage = "You must be atleast 25 year to work in L&T Info. ")]
        public DateTime? Dob { get; set; }
        [DataType(DataType.EmailAddress)]
        [Remote("EmailCheck", "Emp", ErrorMessage = "Duplicate Email")]
        public string Email { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
