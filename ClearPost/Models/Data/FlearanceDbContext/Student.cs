using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Student
    {
        public Student()
        {
            Fees = new HashSet<Fees>();
            Halls = new HashSet<Halls>();
            Library = new HashSet<Library>();
            Sports = new HashSet<Sports>();
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Fees> Fees { get; set; }
        public virtual ICollection<Halls> Halls { get; set; }
        public virtual ICollection<Library> Library { get; set; }
        public virtual ICollection<Sports> Sports { get; set; }
    }
}
