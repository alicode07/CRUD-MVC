using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagement.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Name")]
        public string? Emp_Name { get; set; }
        [Required, Range(18,65)]
        [DisplayName("Age")]
        public int Emp_Age { get; set; }
        [Required ]
        [DisplayName("Gender")]
        public string? Emp_Gender { get; set; }
        [Required, StringLength(50)]
        [DisplayName("Mobile Number")]
        public string? Emp_Mobile { get; set; }
        [Required, Range(0,int.MaxValue)]
        [DisplayName("Salary")]
        public int Emp_Salary { get; set; }
        [DisplayName("Employment Status")]
        //[Required, StringLength(200)]
        public bool Emp_Status { get; set; }
        [ForeignKey ("Department")]
        [Required(ErrorMessage = "Please Select a Department.")]
        public int Dept_Id  { get; set;}
        [DisplayName("Department Name")]
        public Department? Department { get; set; }
    }
}
