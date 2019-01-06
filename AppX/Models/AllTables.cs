using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppX.Models
{
    public class AllTables
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Employee")]
        public string Emp_name { get; set; }

        [Display(Name = "Position")]
        public string Job_name { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Hire_date { get; set; }

        [Display(Name = "Salary (Euro)")]
        public int Salary { get; set; }

        [Display(Name = "Department")]
        public string Dep_name { get; set; }

        [Display(Name = "Location")]
        public string Dep_location { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Work Log")]
        public int Wl_id { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start_time { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime End_time { get; set; }
    }
}