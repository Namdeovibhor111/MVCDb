using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCDb.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }
        [Required(ErrorMessage ="Id is required!!")]
        [Display(Name="Department Code")]
        public int Id { get; set; }
        [Display(Name="Department Name")]
        [Required(ErrorMessage = "Nam required!!")]
        public string Name { get; set; }
        [Display(Name="Location")]
        [StringLength(25, ErrorMessage = "Minimum lentgh is 3",MinimumLength = 3)]
        public string Location { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
        
    }
}
