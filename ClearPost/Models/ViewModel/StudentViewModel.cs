using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public string DepartName { get; set; }
        public SelectList DepartList{ get; set; }
    }
}
