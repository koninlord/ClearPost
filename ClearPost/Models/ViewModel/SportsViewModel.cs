using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.ViewModel
{
    public class SportsViewModel
    {
        public int SportID { get; set; }
        public string SportsType { get; set; }
        public string IsOwingKit { get; set; }
        public int StudentID { get; set; }

        public string FullName { get; set; }
        public SelectList StudentIndexList { get; set; }
        public SelectList StudentDepartList { get; set; }
        
    }
}
