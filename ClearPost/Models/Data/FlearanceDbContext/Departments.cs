using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Departments
    {
        public Departments()
        {
            Student = new HashSet<Student>();
        }

        public int DepartmentId { get; set; }
        public string DepartName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
