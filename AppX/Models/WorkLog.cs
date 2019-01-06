using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppX.Models
{
    public class WorkLog
    {
        [Key]
        public int Wl_id { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start_time { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime End_time { get; set; }

        public int Emp_id { get; set; }

        public Employee CurrentEmployee { get; set; }
    }
}