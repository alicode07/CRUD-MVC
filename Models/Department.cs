using System.ComponentModel.DataAnnotations;

namespace HrManagement.Models
{
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        [Required, StringLength(100)]
        public string? DepartmentName{ get; set; }
       
     
    }
}
