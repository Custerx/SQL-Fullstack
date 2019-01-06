using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppX.Models
{
    public class Departmentx
    {
        [Key]
        [Required]
        public int Dep_id { get; set; }

        [Required]
        [Display(Name = "Department")]
        [StringLength(40, MinimumLength = 1)]
        public string Dep_name { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(40, MinimumLength = 1)]
        public string Dep_location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}