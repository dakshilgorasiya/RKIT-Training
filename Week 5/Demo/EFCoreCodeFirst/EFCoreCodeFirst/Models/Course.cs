using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirst.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<Student> Students { get; set; }
    }
}
