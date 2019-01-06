using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppX.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Employee")]
        public int Emp_id { get; set; }

        [Required]
        [Display(Name = "Street")]
        [StringLength(40, MinimumLength = 1)]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [Range(10000, 99999)]
        public int Zip { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(40, MinimumLength = 1)]
        public string City { get; set; }

        public virtual Employee Employee { get; set; }
    }
}