using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AppX.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        [StringLength(40, MinimumLength = 1)]
        public string Emp_name { get; set; }

        [Required]
        [Display(Name = "Position")]
        [StringLength(40, MinimumLength = 1)]
        public string Job_name { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Hire_date { get; set; }

        [Required]
        [Display(Name = "Salary (Euro)")]
        [Range(1000, 50000)]
        public int Salary { get; set; }

        [Display(Name = "Department ID")]
        public int Dep_id { get; set; }

        [Display(Name = "Department")]
        public Departmentx CurrentDepartment { get; set; }

        [Display(Name = "Address")]
        public virtual Address CurrentAddress { get; set; }

        public ICollection<WorkLog> WorkLogs { get; set; }
    }

    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departmentx> Departmentxes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship between Departmentx and Employee
            modelBuilder.Entity<Employee>()
                .HasRequired<Departmentx>(s => s.CurrentDepartment)
                .WithMany(g => g.Employees)
                .HasForeignKey<int>(s => s.Dep_id);

            // Configure Employee as FK for CurrentAddress
            modelBuilder.Entity<Employee>()
                .HasRequired<Address>(s => s.CurrentAddress)
                .WithRequiredPrincipal(ad => ad.Employee);

            // configures one-to-many relationship between Employee and WorkLog
            modelBuilder.Entity<Employee>()
                .HasMany<WorkLog>(g => g.WorkLogs)
                .WithRequired(s => s.CurrentEmployee)
                .HasForeignKey<int>(k => k.Emp_id)
                .WillCascadeOnDelete();
        }
    }
}