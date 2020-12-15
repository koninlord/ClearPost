using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.ViewModel
{
    public class HallViewModel
    {
        public int HallID { get; set; }
        public string HallName { get; set; }
        public string KeyReturned { get; set; }
        public string IsOwing { get; set; }
        public int StudentID { get; set; }
        public string FullName { get; set; }

        public SelectList StudentIndexList { get; set; }
    }
}
