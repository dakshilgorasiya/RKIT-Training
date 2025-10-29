using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<Course> Courses { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
