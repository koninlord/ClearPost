using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.ViewModel
{
    public class FeesViewModel
    {
        public int FeeID { get; set; }
        public string FeeAmount { get; set; }
        public string IsOwing { get; set; }
        public string AmountPaid { get; set; }
        public string AmountOwing { get; set; }
        public int StudentID { get; set; }
        public string FullName { get; set; }

        public SelectList StudentIndexList { get; set; }
        public SelectList StudentDepartList { get; set; }

    }
}
